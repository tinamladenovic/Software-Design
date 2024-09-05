namespace Explorer.Stakeholders.Core.UseCases
{
    using AutoMapper;
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Stakeholders.API.Dtos;
    using Explorer.Stakeholders.API.Public;
    using Explorer.Stakeholders.Core.Domain;
    using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
    using FluentResults;

    public class ApplicationRateService : CrudService<ApplicationRateDto, ApplicationRate>, IApplicationRateService
    {
        private readonly IApplicationRateRepository _repository;
        public ApplicationRateService(ICrudRepository<ApplicationRate> crudRepository,
            IApplicationRateRepository repository, IMapper mapper) : base(crudRepository, mapper)
        {
            _repository = repository;
        }

        public new Result<PagedResult<ApplicationRateDto>> GetPaged(int page, int pageSize)
        {
            var result = _repository.GetApplicationRates(page, pageSize);
            return MapToDto(result);
        }


    }
}
