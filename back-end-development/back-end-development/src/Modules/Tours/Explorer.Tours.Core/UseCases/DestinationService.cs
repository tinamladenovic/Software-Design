using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.API.Public;
using Explorer.Tours.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Tours.Core.Domain.RepositoryInterfaces;

namespace Explorer.Tours.Core.UseCases
{
    public class DestinationService : CrudService<DestinationDto, Destination>, IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;
        
        public DestinationService(IDestinationRepository destinationRepository, IMapper mapper) : base(destinationRepository, mapper)
        {
            _destinationRepository = destinationRepository;
        }

        public Result<DestinationDto> Create(DestinationDto entity, long personId)
        {
            entity.PersonId = personId;
            return base.Create(entity);
        }

        public Result<PagedResult<DestinationDto>> GetPagedForAuthor(long authorId, int page, int pageSize)
        {
            var result = _destinationRepository.GetPagedForAuthor(authorId, page, pageSize);
            return MapToDto(result);
        }

        public Result Delete(int id, long personId)
        {
            var destination = GetUntracked(id);
            if (destination.IsFailed)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Destination not found");
            }
            if ( destination.Value.PersonId != personId)
            {
                return Result.Fail(FailureCode.Forbidden).WithError("Unauthorized delete attempt");
            }
            return base.Delete(id);
        }

        public Result<DestinationDto> Update(DestinationDto destination, long personId)
        {
            var existingDestination = GetUntracked((int)destination.Id);
            if (existingDestination.IsFailed)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Destination not found");
            }
            if (existingDestination.Value.PersonId != personId)
            {
                return Result.Fail(FailureCode.Forbidden).WithError("Unauthorized delete attempt");
            }
            return base.Update(destination);
        }

        public Result<PagedResult<DestinationDto>> GetPagedPublic(int page, int pageSize)
        {
            var result = GetPaged(page, pageSize);
            var accepted = result.Value.Results.Where(d => d.PublicRequest.Status == RequestStatusDto.Accepted).ToList();
            var publicResult = new PagedResult<DestinationDto>(accepted, accepted.Count);
            return Result.Ok(publicResult);
        }
    }
}
