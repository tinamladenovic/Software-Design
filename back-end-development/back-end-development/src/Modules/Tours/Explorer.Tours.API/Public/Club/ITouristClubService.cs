using Explorer.Tours.API.Dtos;
using FluentResults;
using Explorer.BuildingBlocks.Core.UseCases;

namespace Explorer.Tours.API.Public.Club;

public interface ITouristClubService
{
    Result<PagedResult<TouristClubDto>> GetPaged(int page, int pageSize);
    Result<TouristClubDto> Get(long id);
    Result<TouristClubDto> Create(TouristClubDto touristClub);
    Result<TouristClubDto> Update(TouristClubDto touristClub);
    Result Delete(int id);
    Result<List<TouristClubDto>> GetClubsForOwner(int id);
}
