namespace Explorer.Stakeholders.API.Public
{
    using Explorer.BuildingBlocks.Core.UseCases;
    using Explorer.Stakeholders.API.Dtos;
    using FluentResults;

    public interface IApplicationRateService
    {
        Result<PagedResult<ApplicationRateDto>> GetPaged(int page, int pageSize);
        Result<ApplicationRateDto> Create(ApplicationRateDto equipment);
        Result<ApplicationRateDto> Update(ApplicationRateDto equipment);
        Result Delete(int id);

    }
}
