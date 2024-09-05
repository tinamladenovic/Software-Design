using AutoMapper;
using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.API.Dtos;
using Explorer.Tours.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;
using Explorer.Tours.Core.Domain.TourExecutions;
using Explorer.Tours.API.Dtos.Execution;
using Explorer.Tours.Core.Domain.ValueObjects;
using Explorer.Encounters.API.Dtos;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Tours.API.Dtos.Coupon;


namespace Explorer.Tours.Core.Mappers;

public class ToursProfile : Profile
{
    public ToursProfile()
    {
        CreateMap<EquipmentDto, Equipment>().ReverseMap();
        CreateMap<TourPreferencesDto, TourPreferences>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => Enum.Parse(typeof(DestinationType), src.Rating)))
            .ForMember(dest => dest.TourTravelMethod, opt => opt.MapFrom(src => Enum.Parse(typeof(DestinationType), src.TourTravelMethod)))
            .ForMember(dest => dest.TourDifficult, opt => opt.MapFrom(src => Enum.Parse(typeof(DestinationType), src.TourDifficult)));
        CreateMap<TourPreferences, TourPreferencesDto>()
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.ToString()))
            .ForMember(dest => dest.TourTravelMethod, opt => opt.MapFrom(src => src.TourTravelMethod.ToString()))
            .ForMember(dest => dest.TourDifficult, opt => opt.MapFrom(src => src.TourDifficult.ToString()));
        CreateMap<Destination, DestinationDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.PublicRequest, opt => opt.MapFrom(src =>
                src.Request.Status == CheckpointRequestStatus.Rejected ? new PublicRequestDto(RequestStatusDto.Rejected, src.Request.Comment) : src.Request.Status == CheckpointRequestStatus.Pending ? new PublicRequestDto(RequestStatusDto.Pending, src.Request.Comment) : new PublicRequestDto(RequestStatusDto.Accepted, src.Request.Comment)
                ));
        CreateMap<DestinationDto, Destination>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse(typeof(DestinationType), src.Type)))
            .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.PublicRequest != null ? new PublicRequest(CheckpointRequestStatus.Pending, null) : null));
        CreateMap<TouristClubDto, TouristClub>().ReverseMap();
        CreateMap<TouristEquipmentDTO, TouristEquipment>().ReverseMap();
        CreateMap<TourDto, Tour>().ReverseMap();

        CreateMap<ReportDto, Report>().ReverseMap();
        CreateMap<ReportCommentDto, ReportComment>().ReverseMap();

        CreateMap<CheckpointDto, Checkpoint>()
            .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => new Coordinate(src.Latitude, src.Longitude)))
            .ForMember(dest => dest.Request,
                opt => opt.MapFrom(src => src.PublicRequest))
            .ForMember(dest => dest.Request, opt => opt.MapFrom(src => src.PublicRequest != null ? new PublicRequest(CheckpointRequestStatus.Pending, null) : null));


        CreateMap<Checkpoint, CheckpointDto>()
            .ForMember(check => check.Latitude, opt => opt.MapFrom(src => src.Coordinates.Latitude))
            .ForMember(check => check.Longitude, opt => opt.MapFrom(src => src.Coordinates.Longitude))
            .ForMember(check => check.PublicRequest,
                opt => opt.MapFrom(src =>
                    src.Request.Status == CheckpointRequestStatus.Rejected ? new PublicRequestDto(RequestStatusDto.Rejected, src.Request.Comment) : src.Request.Status == CheckpointRequestStatus.Pending ? new PublicRequestDto(RequestStatusDto.Pending, src.Request.Comment) : new PublicRequestDto(RequestStatusDto.Accepted, src.Request.Comment)
                ));

        CreateMap<TourReviewDto, TourReview>().ReverseMap();


        CreateMap<TourDto, Tour>()
        .ForMember(tour => tour.TravelTimeAndMethod, opt => opt.MapFrom(src => src.TravelTimeAndMethod))
        .ForMember(tour => tour.TourEquipment, opt => opt.MapFrom(src => src.TourEquipment));
        CreateMap<Tour, TourDto>()
            .ForMember(dest => dest.TravelTimeAndMethod, opt => opt.MapFrom(src => src.TravelTimeAndMethod))
            .ForMember(dest => dest.TourEquipment, opt => opt.MapFrom(src => src.TourEquipment));

        CreateMap<CompositeTourDto, CompositeTour>()
            .ForMember(compositeTour => compositeTour.Tours, opt => opt.MapFrom(src => src.Tours));
        CreateMap<CompositeTour, CompositeTourDto>()
            .ForMember(dest => dest.Tours, opt => opt.MapFrom(src => src.Tours))
            .ForMember(dest => dest.Checkpoints, opt => opt.MapFrom(src => src.Checkpoints))
            .ForMember(dest => dest.Equipments, opt => opt.MapFrom(src => src.Equipments));
            

        CreateMap<TravelTimeAndMethodDto,TravelTimeAndMethod >().ReverseMap();
        CreateMap<EquipmentDto, Equipment>().ReverseMap();

        
        CreateMap<Tour,  TourPreviewDto> ().ForMember(dest => dest.Checkpoints, opt => opt.MapFrom(src => src.Checkpoints))
            .ForMember(dest => dest.TourReviews,opt => opt.MapFrom(src => src.TourReviews)).ReverseMap();

        CreateMap<TourRatingDto, TourRating>().ReverseMap();
        CreateMap<TourExecutionDto, TourExecution>()
            .ForMember(dest => dest.CheckpointStatuses, opt => opt.MapFrom(src => src.CheckpointStatuses));
        CreateMap<TourExecution, TourExecutionDto>().ForMember(dest => dest.CheckpointStatuses, opt => opt.MapFrom(
            src => src.CheckpointStatuses));
        CreateMap<CheckpointStatusDto, CheckpointStatus>().ReverseMap();
        CreateMap<CoordinateDto, Coordinate>().ReverseMap();
        CreateMap<SaleDto, Sale>().ReverseMap();
        CreateMap<TourSaleConnectionDto, TourSaleConnection>().ReverseMap();

       
        CreateMap<TourCoupon, CouponResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.CouponHash, opt => opt.MapFrom(src => src.CouponHash));

        CreateMap<TourCoupon, CouponDto>()
            .ForMember(dest => dest.CouponHash, opt => opt.MapFrom(src => src.CouponHash))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CouponIssuerId))
            .ForMember(dest => dest.TourId, opt => opt.MapFrom(src => src.ApplicableTourId))
            .ForMember(dest => dest.DiscountProcentage, opt => opt.MapFrom(src => src.DiscountPercentage))
            .ForMember(dest => dest.IsApplicableToAllUserTours, opt => opt.MapFrom(src => src.IsApplicableToAllUserTours));

        CreateMap<Questionnaire,QuestionnaireDto>().ReverseMap();
        CreateMap<AnswerDates,AnswerDateDto>().ReverseMap();
        CreateMap<StakeholdersCoordinateDto, Coordinate>().ReverseMap();
    }
}