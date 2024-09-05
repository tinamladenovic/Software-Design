using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Stakeholders.API.Public;
using Explorer.Tours.API.Dtos;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Xunit.Sdk;

namespace Explorer.API.Controllers.Tourist.ShoppingCart
{
    [Authorize(Policy = "touristPolicy")]
    [Route("api/order/")]
    public class OrderController: BaseApiController
    {
        protected readonly IOrderService _orderService;
        protected readonly IShoppingCartService _shoppingCartService;
        protected readonly IPersonService _personServce;
        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService, IPersonService personService) 
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _personServce = personService;
        }

        [HttpPost("{userId:int}")]
        public ActionResult<ShoppingCartDto> CreateOrder([FromBody] List<long> tourIds,int userId)
        {
            var email = _personServce.GetPersonEmail(userId).Value;
            var result = _orderService.CreateOrder(userId,tourIds,email);

            //var result = _shoppingCartService.ClearCart(userId);

            var response = CreateResponse(result);
            return response;
        }

        [HttpGet("orders/{userId:int}")]
        public ActionResult<PagedResult<OrderDto>> GetTourstOrder(int userId, [FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _orderService.GetByUser(page, pageSize, userId);
            return CreateResponse(result);
        }
    }
}
