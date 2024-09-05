using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.Core.UseCases.Tourist.Execution
{
    public enum ErrorType
    {
        AlreadyActive,
        AlreadyCompleted,
        Success
    }
    public class EncounterExecutionService : BaseService<EncounterExecutionDto, EncounterExecution>, IEncounterExecutionService, IInternalEncounterExecutionService
    {
        private readonly IEncounterExecutionRepository _repository;
        private readonly IEncounterService _encounterService;
        private readonly IMapper _mapper;

        public EncounterExecutionService(IEncounterExecutionRepository executionRepository, IEncounterService encounterService, IMapper mapper) : base(mapper)
        {
            _repository = executionRepository;
            _encounterService = encounterService;
            _mapper = mapper;
        }

        public Result<EncounterExecutionDto> Abandon(long executionId, long touristId)
        {
            var encounterExecution = _repository.GetUntracked(executionId);
            if (encounterExecution.TouristId != touristId)
                return Result.Fail(FailureCode.Forbidden);

            try
            {
                encounterExecution.Abandon();
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
            return Update(encounterExecution);
        }

        public Result<EncounterExecutionDto> Activate(long encounterId, long touristId, EncounterCoordinateDto currentPosition)
        {
            var result = _encounterService.Get(encounterId);
            if (result.IsFailed)
                return Result.Fail(FailureCode.NotFound);

            var encounter = result.Value;
            if (encounter.Status != EncounterStatusDto.Active)
                return Result.Fail(FailureCode.NotFound);

            var status = IfCanActivate(encounter, touristId);
            if(status != ErrorType.Success)
            {
                return ReturnMatchingError(status);
            } 

            return ActivateEncounter(_mapper.Map<Encounter>(encounter), touristId, _mapper.Map<Coordinate>(currentPosition));
        }

        private Result<EncounterExecutionDto> ActivateEncounter(Encounter encounter, long touristId, Coordinate currentPosition)
        {
            try
            {
                var execution = new EncounterExecution(encounter, touristId, EncounterExecutionStatus.Active, currentPosition);
                return MapToDto(_repository.Create(execution));
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
        }

        public Result<EncounterExecutionDto> CheckIfCompleted(long executionId, long touristId, EncounterCoordinateDto currentPosition)
        {
            var encounterExecution = _repository.Get(executionId);
            if (encounterExecution.TouristId != touristId)
                return Result.Fail(FailureCode.Forbidden);

            var encounter = _encounterService.Get(encounterExecution.EncounterId).Value;

            var processedExecution = new Result<EncounterExecutionDto>();
            switch (encounter.Type)
            {
                case EncounterTypeDto.HiddenLocation:
                    encounterExecution.CheckIfCompletedHiddenLocation(_mapper.Map<Encounter>(encounter), _mapper.Map<Coordinate>(currentPosition));
                    processedExecution = Update(encounterExecution);
                    break;
                case EncounterTypeDto.Social:
                    processedExecution = CheckIfCompletedSocial(encounterExecution, _mapper.Map<Encounter>(encounter), _mapper.Map<Coordinate>(currentPosition));
                    break;
                case EncounterTypeDto.Misc:
                    encounterExecution.UpdateLastActivityInformation(_mapper.Map<Coordinate>(currentPosition));
                    processedExecution = Update(encounterExecution);
                    break;
                default:
                    return Result.Fail(FailureCode.Internal).WithError("Internal server error!");
            }

            if (processedExecution.Value.Status == EncounterExecutionStatusDto.Completed)
            {
                AddXpToTourist(touristId, encounter.Xp);
            }
            return processedExecution;
        }

        private Result<EncounterExecutionDto> CheckIfCompletedSocial(EncounterExecution encounterExecution, Encounter encounter, Coordinate currentPosition)
        {
            //If the user goes out of range - he abbandons the encounter
            if (!encounter.IsWithinRange(currentPosition))
            {
                encounterExecution.Abandon();
                return Update(encounterExecution);
            }

            var allActive = _repository.GetAllActiveForEncounterId(encounter.Id).Results;
            if (allActive.Count() >= encounter.SocialEncounterRequiredPeople)
            {
                allActive.ForEach(e =>
                {
                    e.Complete(currentPosition);
                    Update(e);
                });
            }
            return MapToDto(_repository.Get(encounterExecution.Id));
        }


        public Result<EncounterExecutionDto> CompleteMiscEncounter(long executionId, long touristId)
        {
            var encounterExecution = _repository.GetUntracked(executionId);
            if (encounterExecution.TouristId != touristId)
                return Result.Fail(FailureCode.Forbidden);

            try
            {
                encounterExecution.Complete();
                var encounter = _encounterService.Get(encounterExecution.EncounterId).Value;
                AddXpToTourist(touristId, encounter.Xp);
            }
            catch (Exception ex)
            {
                return Result.Fail(FailureCode.InvalidArgument).WithError(ex.Message);
            }
            return Update(encounterExecution);
        }

        private Result<EncounterExecutionDto> Update(EncounterExecution execution)
        {
            try
            {
                var result = _repository.Update(execution);
                return MapToDto(result);
            }
            catch (KeyNotFoundException ex)
            {
                return Result.Fail(FailureCode.NotFound).WithError(ex.Message);
            }
        }

        private ErrorType IfCanActivate(EncounterDto encounter, long touristId)
        {
            var touristExecutions = _repository.GetAllForTouristId(touristId);
            foreach (EncounterExecution enc in touristExecutions.Results)
            {
                if (enc.Status == EncounterExecutionStatus.Active) return ErrorType.AlreadyActive;
                if (enc.EncounterId == encounter.Id && enc.Status == EncounterExecutionStatus.Completed) return ErrorType.AlreadyCompleted;
            }
            return ErrorType.Success;
        }

        private Result<EncounterExecutionDto> ReturnMatchingError(ErrorType status)
        {
            switch (status)
            {
                case ErrorType.AlreadyCompleted:
                    return Result.Fail(FailureCode.InvalidArgument).WithError("Encounter already completed!");
                case ErrorType.AlreadyActive:
                    return Result.Fail(FailureCode.InvalidArgument).WithError("Encounter already activated!");
                default:
                    return Result.Fail(FailureCode.Internal).WithError("Internal server error!");
            }
        }

        public Result<List<EncounterExecutionDto>> GetByEncounterId(long encounterId)
        {
            return MapToDto(_repository.GetAllForEncounterId(encounterId).Results);
        }

        public Result<EncounterStatisticsDto> GetStatisticsForUser(long userId)
        {
            var encounters = _repository.GetByUserId(userId);
            var result = new EncounterStatisticsDto();
            foreach (var ex in encounters.Results)
            {
                result.EncounterId = ex.EncounterId;
                switch (ex.Status)
                {
                    case EncounterExecutionStatus.Active:
                        result.ActiveCount++;
                        break;
                    case EncounterExecutionStatus.Abandoned:
                        result.AbandonedCount++;
                        break;
                    case EncounterExecutionStatus.Completed:
                        result.CompletedCount++;
                        break;

                }
            }
            return result;
        }

        private void AddXpToTourist(long touristId, int xp)
        {
            // TO DO: Add xp to tourist
        }
    }
}
