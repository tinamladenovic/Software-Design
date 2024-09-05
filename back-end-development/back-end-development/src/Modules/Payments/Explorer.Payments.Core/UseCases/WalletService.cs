using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Internal;
using Explorer.Payments.API.Public.ShoppingCart;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.UseCases
{
    public class WalletService : BaseService<WalletDto, Wallet>, IInternalWalletService, IWalletService
    {
        protected readonly IWalletRepository _walletRepository;

        public WalletService(IMapper mapper, IWalletRepository walletRepository) : base(mapper)
        {
            _walletRepository = walletRepository;
        }

        public Result<WalletDto> Create(long id)
        {
            var existingWallet = _walletRepository.GetByUserId(id);
            if (existingWallet != null)
            {
                return Result.Fail(FailureCode.Conflict).WithError("Wallet with this userId already exists!.");
            }
            try
            {
                WalletDto dto = new WalletDto(id);
                Wallet wallet = MapToDomain(dto);
                var result = _walletRepository.Create(wallet);
                return MapToDto(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public Result<WalletDto> Get(long userId)
        {
            try
            {
                var result = _walletRepository.GetByUserId(userId);
                return MapToDto(result);

            }
            catch (KeyNotFoundException e)
            {
                return Result.Fail(FailureCode.NotFound).WithError(e.Message);
            }
        }

        public Result<WalletDto> AddAdventureCoins(long userId, double coins)
        {
            var wallet = _walletRepository.GetByUserId(userId);
            if (wallet == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Wallet not found!");
            }

            wallet.DepositAdventureCoins(coins);
            var result = _walletRepository.UpdateWallet(wallet);
            return MapToDto(result);
        }

        public Result<WalletDto> RemoveAdventureCoins(long userId, double coins)
        {
            var wallet = _walletRepository.GetByUserId(userId);
            if (wallet == null)
            {
                return Result.Fail(FailureCode.NotFound).WithError("Wallet not found!");
            }

            wallet.WithdrawAdventureCoins(coins);
            var result = _walletRepository.UpdateWallet(wallet);
            return MapToDto(result);
        }
    }
}
