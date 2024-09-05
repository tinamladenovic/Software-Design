using AutoMapper;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using Explorer.Payments.Core.Domain.TourPackages;

namespace Explorer.Payments.Core.Mappers;

public class PaymentsProfile : Profile
{
    public PaymentsProfile()
    {
        CreateMap<ShoppingCartDto, ShoppingCart>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.BundleItems, opt => opt.MapFrom(src => src.BundleItems));

        CreateMap<ShoppingCart, ShoppingCartDto>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
            .ForMember(dest => dest.BundleItems, opt => opt.MapFrom(src => src.BundleItems));

        CreateMap<BundleItemDto, BundleItem>().ReverseMap(); // Assuming you have a mapping for BundleItemDto to BundleItem
        CreateMap<BundleItem, BundleItemDto>().ReverseMap();
        CreateMap<OrderItemDto, OrderItem>().ReverseMap();
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap<PaymentRecordDto, PaymentRecord>().ReverseMap();
        CreateMap<Wallet, WalletDto>().ReverseMap();
        CreateMap<TourBundleDto, TourBundle>()
            .ForMember(dest => dest.Tours, opt => opt.MapFrom(src => src.Tours));
        CreateMap<TourBundle, TourBundleDto>().ForMember(dest => dest.Tours, opt => opt.MapFrom(
            src => src.Tours));

        CreateMap<TourStatusDto, TourStatus>().ReverseMap();
    }
}

