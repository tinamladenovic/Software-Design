﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IWalletRepository
    {
        Wallet Create(Wallet wallet);
        Wallet GetByUserId(long userId);
        Wallet UpdateWallet(Wallet wallet);
    }
}
