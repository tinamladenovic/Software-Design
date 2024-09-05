using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;

namespace Explorer.Stakeholders.Core.Mappers;

public class TouristNoteProfile : Profile
{
    public TouristNoteProfile() 
    {
        CreateMap<TouristNoteDto, TouristNote>().ReverseMap();
    }
}
