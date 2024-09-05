using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.API.Dtos
{
    public class WalletDto
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long AdventureCoins { get; set; }

        public WalletDto(long userId, long adventureCoins)
        {
            UserId = userId;
            AdventureCoins = adventureCoins;
        }
        public WalletDto(long id)
        {
            UserId = id;
            AdventureCoins = 0;
        }
        public WalletDto(){}
    }
}
