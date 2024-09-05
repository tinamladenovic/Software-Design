using Explorer.Payments.API.Dtos;
using FluentResults;

namespace Explorer.Payments.API.Public.ShoppingCart
{
    public interface IWalletService
    {
        Result<WalletDto> Get(long userId);
        Result<WalletDto> AddAdventureCoins(long userId, double coins);
        Result<WalletDto> RemoveAdventureCoins(long userId, double coins);
    }
}
