using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class ShoppingSessionRepository : IShoppingSessionRepository
    {
        private readonly PaymentsContext _dbContext;
        private readonly DbSet<ShoppingSessionEvent> _dbSet;

        public ShoppingSessionRepository(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<ShoppingSessionEvent>();
        }

        public ShoppingSessionEvent Create(ShoppingSessionEvent shoppingSessionEvent)
        {
            try
            {
                _dbSet.Add(shoppingSessionEvent);
                _dbContext.SaveChanges();
                return shoppingSessionEvent;
            }
            catch (Exception ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public ShoppingSessionEvent GetByAggregateId(long aggregateId)
        {
            try
            {
                // Traži odgovarajući zapis koji ima određeni aggregateId i isActive == true
                var shoppingSessionEvent = _dbSet.
                    FirstOrDefault(e => e.AggregateId == aggregateId && e.isActive);


                return shoppingSessionEvent;
            }
            catch (Exception ex)
            {
                // Handle the exception...
                return null; // ili neki drugi odgovarajući način rukovanja greškom
            }
        }


        public void UpdateShoppingSessionEvent(ShoppingSessionEvent shoppingEvent)
        {
            try
            {
                _dbContext.Update(shoppingEvent);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
    }
}
