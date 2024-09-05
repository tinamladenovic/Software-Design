using AutoMapper;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Tours.API.Dtos;
using System.Net.Sockets;

namespace Explorer.Stakeholders.Core.Mappers;

public class StakeholderProfile : Profile
{
    public StakeholderProfile()
    {
        CreateMap<RequestToJoinClubDto, RequestToJoinClub>().ReverseMap();
        CreateMap<ClubRequestDto, ClubRequest>().ReverseMap();
        CreateMap<ClubUsersDto, ClubUsers>().ReverseMap();
        CreateMap<ApplicationRateDto, ApplicationRate>()
            .ForMember(dto => dto.Id, entity => entity.Ignore());
        CreateMap<ApplicationRate, ApplicationRateDto>()
               .ForMember(dto => dto.Name, entity => entity.MapFrom(e => e.Person.Name))
               .ForMember(dto => dto.Surname, entity => entity.MapFrom(e => e.Person.Surname));

        CreateMap<UpdatePersonDTO,Person>().ReverseMap();
        CreateMap<TouristNoteDto, TouristNote>().ReverseMap();
        CreateMap<FollowersDto, Followers>().ReverseMap();
        CreateMap<NotificationDto, Notification>().ReverseMap();
    }
}