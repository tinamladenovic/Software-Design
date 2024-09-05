
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Stakeholders.Infrastructure.Authentication;
using Explorer.Tours.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Explorer.API.Controllers.Tourist.ShoppingCart
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/shoppingCart/")]
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{userId:int}")]
        public ActionResult<ShoppingCartDto> Get(int userId)
        {
            var result = _shoppingCartService.Get(userId);
            return CreateResponse(result);
        }

        
        [HttpPut("addTour/{userId:int}")]
        public ActionResult<OrderItemDto> AddTour([FromBody] OrderItemDto orderItem,int userId)
        {
            var result = _shoppingCartService.AddTour(orderItem,userId);
            return CreateResponse(result);
        }

        [HttpPut("addTourBundle/{userId:int}")]
        public ActionResult<BundleItemDto> AddTourBundle([FromBody] TourBundleDto bundle, int userId)
        {
            var result = _shoppingCartService.AddBundleTours(bundle, userId);
            return CreateResponse(result);
        }

        [HttpDelete("removeTour/{cartId:int}")]
        public ActionResult<ShoppingCartDto> RemoveTour([FromQuery] int tourId, int cartId)
        {
            var result = _shoppingCartService.RemoveTour(tourId, cartId);
            return CreateResponse(result);
        }
        [HttpDelete("removeTourBundle/{cartId:int}")]
        public ActionResult<ShoppingCartDto> RemoveTourBundle([FromQuery] int bundleId, int cartId)
        {
            var result = _shoppingCartService.RemoveTourBundle(bundleId, cartId);
            return CreateResponse(result);
        }

        [HttpPost("addDiscount")]
        public ActionResult<bool> AddDiscount(string couponHash)
        {
            var result = _shoppingCartService.AddDiscount(couponHash, User.UserId());
            return Ok(result);
        }
        
       

    }
}
