namespace Explorer.Stakeholders.Core.Domain.RepositoryInterfaces
{
    using Explorer.BuildingBlocks.Core.UseCases;

    public interface IApplicationRateRepository
    {
        PagedResult<ApplicationRate> GetApplicationRates(int page, int pageSize);
    }
}
