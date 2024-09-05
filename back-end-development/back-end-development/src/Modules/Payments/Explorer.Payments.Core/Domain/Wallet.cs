using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Payments.Core.Domain
{
    public class Wallet : Entity
    {
        public long UserId { get; init; }
        public double AdventureCoins { get; private set; }

        public Wallet()
        {

        }

        public Wallet(long userId, long adventureCoins)
        {
            UserId = userId;
            AdventureCoins = adventureCoins;
        }

        public void DepositAdventureCoins(double coins)
        {
            AdventureCoins += coins;
        }

        public void WithdrawAdventureCoins(double coins)
        {
            AdventureCoins -= coins;
        }
    }
}
