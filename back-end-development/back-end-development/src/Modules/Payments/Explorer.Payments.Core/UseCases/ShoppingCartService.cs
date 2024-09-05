using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using FluentResults;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Core.Domain.TourPackages;
using Status = Explorer.Payments.API.Dtos.Status;

namespace Explorer.Payments.Core.UseCases
{
    public class ShoppingCartService : BaseService<ShoppingCartDto, ShoppingCart>, IShoppingCartService, IInternalShoppingCartService
    {
        protected readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IInternalCouponService _couponService;
        protected readonly IShoppingSession _shoppingSession;
        protected readonly IInternalShoppingSession _internalShoppingSession;
        private IMapper _mapper;
        public ShoppingCartService(IMapper mapper,
                                   IShoppingCartRepository shoppingCartRepository,
                                   IInternalCouponService couponService,
                                   IShoppingSession shoppingSession,
                                   IInternalShoppingSession internalShoppingSession) : base(mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _couponService = couponService;
            _shoppingSession = shoppingSession;
            _mapper = mapper;
            _internalShoppingSession = internalShoppingSession;
        }


        public Result<ShoppingCartDto> Create(long id)
        {
            var existingCart = _shoppingCartRepository.GetByUserId(id);
            if (existingCart != null)
            {
                return Result.Fail(FailureCode.Conflict).WithError("ShoppingCart with the same personId already exists.");
            }
            try
            {
                ShoppingCartDto dto = new ShoppingCartDto(id);
                ShoppingCart shoppingCart = MapToDomain(dto);
                var result = _shoppingCartRepository.Create(shoppingCart);
                return MapToDto(result);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }



        public Result AddDiscount(string discountHash, long userId)
        {
            var result = Get(userId);
            if (_couponService.IsCoupnValid(discountHash) == false)
                return Result.Fail("Coupon is invalid!");


            var shoppingCart = GetCartByUserId(userId);
            _shoppingCartRepository.AddDiscound(shoppingCart.Value.Id, discountHash);

            //CouponDto coupon = _couponService.GetByHash(discountHash);

            if(_couponService.CheckIfIsApplicableToAll(discountHash) is false)
            {
                foreach (var item in shoppingCart.Value.Items)
                {
                    if(item.TourId == _couponService.GetTourByCouponHash(discountHash)) {
                        item.Price = (long)(item.Price * (1 - _couponService.GetDiscounyByCouponHash(discountHash)/100));
                        var cart = _shoppingCartRepository.GetById(shoppingCart.Value.Id);

                        int index = cart.Items.FindIndex(c => c.TourId == item.TourId);
                        if (index != -1)
                        {
                            cart.Items[index] = new OrderItem(item.TourId, item.TourName, item.Price); 
                        }

                        _shoppingCartRepository.Update(cart);
                        _couponService.SetCouponToInvalid(discountHash);
                        //_shoppingSession.AddCouponToShoppingCartEvent(shoppingCart.Value.Id);

                        break;
                    }
                }
            }
            else
            {
                foreach (var item in shoppingCart.Value.Items)
                {

                    if(_couponService.CheckIfAutorApplies(item.TourId, discountHash) != false)
                    {
                        item.Price = (long)(item.Price * (1 - _couponService.GetDiscounyByCouponHash(discountHash) / 100));
                        var cart = _shoppingCartRepository.GetById(shoppingCart.Value.Id);

                        int index = cart.Items.FindIndex(c => c.TourId == item.TourId);
                        if (index != -1)
                        {
                            cart.Items[index] = new OrderItem(item.TourId, item.TourName, item.Price);
                        }

                        _shoppingCartRepository.Update(cart);
                        _couponService.SetCouponToInvalid(discountHash);
                        //_shoppingSession.AddCouponToShoppingCartEvent(shoppingCart.Value.Id);

                    }
                }
            }

            return Result.Ok();
        }

        public Result<ShoppingCartDto> Get(long userId)
        {
            try
            {
                var result = _shoppingCartRepository.GetByUserId(userId);
                result.Items.Remove(result.Items.FirstOrDefault(i => i.TourId == 0));
                result.BundleItems.Remove(result.BundleItems.FirstOrDefault(i => i.Id == 0));
                return MapToDto(result);

            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<OrderItemDto> AddTour(OrderItemDto orderItemDto, int userId)
        {

            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            if (shoppingCart == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("ShoppingCart not found.");
            }

            OrderItem newOrderItem = new OrderItem(orderItemDto.TourId, orderItemDto.TourName, orderItemDto.Price);
            shoppingCart.AddItemToCart(newOrderItem);

            try
            {
                _shoppingCartRepository.AddToCartUpdate(shoppingCart);
                //_shoppingSession.AddTourToShoppingCartEvent(shoppingCart.Id);

                return orderItemDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Result.Fail(FailureCode.Internal).WithError("An error occurred while updating the ShoppingCart.");
            }
        }
        public Result<BundleItemDto> AddBundleTours(TourBundleDto bundle, int userId)
        {

            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            if (shoppingCart == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("ShoppingCart not found.");
            }

            BundleItem item = new BundleItem(bundle.Id, bundle.Name, bundle.Price, _mapper.Map<List<TourStatus>>(bundle.Tours));
            shoppingCart.AddBundleToCart(item);

            try
            {
                _shoppingCartRepository.AddToCartUpdate(shoppingCart);
               /* if (!_internalShoppingSession.CheckActiveShoppingSession(shoppingCart.Id))
                {
                    _internalShoppingSession.OpenShoppingSession(shoppingCart.Id);
                }
                _shoppingSession.AddTourBundleToShoppingCartEvent(shoppingCart.Id);*/
                return Result.Ok(new BundleItemDto(item.Id, item.BundleName, item.Price, _mapper.Map<List<TourStatusDto>>(item.Tours)));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Result.Fail(FailureCode.Internal).WithError("An error occurred while updating the ShoppingCart.");
            }
            

        }

        public Result<ShoppingCartDto> RemoveTour(long tourId, int cartId)
        {
            var shoppingCart = _shoppingCartRepository.GetById(cartId);
            if (shoppingCart == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("ShoppingCart not found.");
            }

            shoppingCart.RemoveItemFromCart(tourId);
            //_shoppingSession.RemoveTourShoppingCartEvent(shoppingCart.Id);
            var result = _shoppingCartRepository.RemoveFromCartUpdate(shoppingCart);
            return MapToDto(result);
        }
        public Result<ShoppingCartDto> RemoveTourBundle(long bundleId, int cartId)
        {
            var shoppingCart = _shoppingCartRepository.GetById(cartId);
            if (shoppingCart == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("ShoppingCart not found.");
            }

            shoppingCart.RemoveBundleItemFromCart(bundleId);
            var result = _shoppingCartRepository.RemoveFromCartUpdate(shoppingCart);
            //_shoppingSession.RemoveTourBundleShoppingCartEvent(shoppingCart.Id);
            return MapToDto(result);
        }
        public Result<ShoppingCartDto> ClearCart(long userId)
        {
            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            if (shoppingCart == null)
            {
                Result.Fail(FailureCode.NotFound).WithError("ShoppingCart not found.");
            }
            shoppingCart.ClearCart();
            //_shoppingSession.CloseShoppingEvent(shoppingCart.Id);
            var clearedCart = _shoppingCartRepository.RemoveFromCartUpdate(shoppingCart);
            return MapToDto(clearedCart);
        }

        public Result<ShoppingCartDto> GetCartByUserId(long userId)
        {
            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            if (shoppingCart == null)
            {
                Result.Fail(FailureCode.NotFound).WithError("ShoppingCart not found.");
            }

            return MapToDto(shoppingCart);
        }

        public double GetCartPrice(long userId)
        {
            var shoppingCart = _shoppingCartRepository.GetByUserId(userId);
            double price = 0;
            foreach( var item in shoppingCart.Items)
            {
                price += item.Price;
            }
            foreach (var item in shoppingCart.BundleItems)
            {
                price += item.Price;
            }
            return price;
        }
    }
}
