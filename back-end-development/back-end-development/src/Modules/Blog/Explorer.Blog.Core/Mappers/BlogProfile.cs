using AutoMapper;
using Explorer.Blog.API.Dtos;
using Explorer.Blog.Core.Domain;
using Explorer.BuildingBlocks.Core.Domain;


namespace Explorer.Blog.Core.Mappers;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<CommentDto, Comment>().ReverseMap();
        CreateMap<RatingDto, Rating>().ReverseMap();
        CreateMap<BlogDto, BlogDom>().ReverseMap()
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
            .ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings));



        //CreateMap<BlogDto, BlogDom>().IncludeAllDerived().ForMember(dest => dest.Ratings, opt => opt.MapFrom(src => src.Ratings.Select());
    }
}