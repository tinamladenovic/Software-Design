using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PaymentsContext _context;
        private readonly DbSet<Order> _dbSet;
        public OrderRepository(PaymentsContext context)
        {
            _context = context;
            _dbSet = _context.Set<Order>();
        }

        public Result<PagedResult<Order>> GetByUserId(int page, int pageSize, long userId)
        {
            var count = _dbSet.Count();
            var orders = _context.Orders.Where(o => o.UserId == userId).ToList();
            if (orders.Count == 0)
            {
                return new PagedResult<Order>(new List<Order>(), count);
            }
            return new PagedResult<Order>(orders.ToList(), count);
        }

        public void CreateOrder(Order order)
        {
            try
            {
                _dbSet.Add(order);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public int GetOrderCount(long tourId)
        {
            return _dbSet.Count(o => o.TourId == tourId);
        }
    }
}
