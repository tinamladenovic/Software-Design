using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly PaymentsContext _dbContext;
        private readonly DbSet<Wallet> _dbSet;

        public WalletRepository(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<Wallet>();
        }

        public Wallet Create(Wallet wallet)
        {
            try
            {
                _dbSet.Add(wallet);
                _dbContext.SaveChanges();
                return wallet;

            }catch(Exception ex) 
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public Wallet GetByUserId(long id)
        {
            var entity = _dbSet.SingleOrDefault(x => x.UserId == id);
            return entity;
        }

        public Wallet UpdateWallet(Wallet wallet)
        {
            try
            {
                _dbContext.Update(wallet);
                _dbContext.SaveChanges();
                return wallet;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
    }
}
