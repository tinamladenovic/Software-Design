using FluentResults;
using Explorer.Payments.API.Dtos;

namespace Explorer.Payments.API.Internal
{
    public interface IInternalShoppingCartService
    {
        Result<ShoppingCartDto> Create(long id);
        Result<ShoppingCartDto> GetCartByUserId(long id);
    }
}
