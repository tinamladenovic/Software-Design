using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.ShoppingCart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers.Tourist.Wallet
{
    [Route("api/wallet/")]
    public class WalletController : BaseApiController
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService _walletService)
        {
            this._walletService = _walletService;
        }

        [Authorize(Policy = "touristAndAdminPolicy")]
        [HttpGet("{userId:int}")]
        public ActionResult<WalletDto> Get(int userId)
        {
            var result = _walletService.Get(userId);
            return CreateResponse(result);
        }

        [Authorize(Policy = "administratorPolicy")]
        [HttpPut("addCoins/{userId:int}")]
        public ActionResult<WalletDto> AddCoins([FromBody] int numberOfCoins, int userId)
        {
            var result = _walletService.AddAdventureCoins(userId, numberOfCoins);
            return CreateResponse(result);
        }


    }
}
