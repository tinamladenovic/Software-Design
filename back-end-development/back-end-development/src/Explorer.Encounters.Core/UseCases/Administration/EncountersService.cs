using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Encounters.API.Dtos;
using Explorer.Encounters.API.Public;
using Explorer.Encounters.Core.Domain;
using FluentResults;
using Explorer.Encounters.API.Internal;
using Explorer.Encounters.Core.Domain.NewFolder;
using Explorer.Encounters.Core.Domain.RepositoryInterfaces;

namespace Explorer.Encounters.Core.UseCases.Administration
{
    public class EncountersService : CrudService<EncounterDto, Encounter>, IEncounterService, IInternalEncounterService
    {
        private readonly IEncountersRepository _repository;
        private readonly IEncounterExecutionRepository _executionRepository;
        private readonly IMapper _mapper;

        public EncountersService(IEncountersRepository repository, IEncounterExecutionRepository executionRepository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _executionRepository = executionRepository;
            _mapper = mapper;
        }

        public Result<EncounterStatisticsDto> GetStatistics(long encounterId)
        {
            var encounter = _repository.GetById(encounterId);
            List<EncounterExecution> allExecutions = _executionRepository.GetAllForEncounterId(encounterId).Results;
            var result = new EncounterStatisticsDto();
            foreach(var ex in  allExecutions)
            {
                result.EncounterId = ex.EncounterId;
                switch(ex.Status) 
                {
                    case EncounterExecutionStatus.Active: result.ActiveCount++;
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

        public Result<PagedResult<EncounterDto>> GetAllCheckpointRelated()
        {
            return MapToDto(_repository.GetAllCheckpointRelated());
        }

        public Result<EncounterDto> GetForCheckpoint(long checkpointId)
        {
            var encounter = _repository.GetForCheckpoint(checkpointId);
            return encounter != null ? MapToDto(encounter) : Result.Fail(FailureCode.NotFound);
        }

        public Result<PagedResult<EncounterDto>> GetAllCheckpointUnrelated()
        {
            return MapToDto(_repository.GetAllCheckpointUnrelated());
        }
        public Result<PagedResult<EncounterDto>> GetAllActive()
        {
            return MapToDto(_repository.GetAllActive());
        }
    }
}
