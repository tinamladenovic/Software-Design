using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Payments.Core.Domain.ShoppingCarts;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly PaymentsContext _dbContext;
        private readonly DbSet<ShoppingCart> _dbSet;

        public ShoppingCartRepository(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<ShoppingCart>();
        }
        public ShoppingCart GetById(long id)
        {
            var entity = _dbSet.Find(id);
            return entity;

        }

        public ShoppingCart GetByUserId(long id)
        {
            var entity = _dbSet.SingleOrDefault(cart => cart.UserId == id);
            return entity;
        }

        public ShoppingCart Create(ShoppingCart shoppingCart)
        {
            try
            {
                _dbSet.Add(shoppingCart);
                _dbContext.SaveChanges();
                return shoppingCart;
            }
            catch (Exception ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public void AddToCartUpdate(ShoppingCart cart)
        {
            try
            {
                _dbContext.Update(cart);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
        public ShoppingCart RemoveFromCartUpdate(ShoppingCart cart)
        {
            try
            {
                _dbContext.Update(cart);
                _dbContext.SaveChanges();
                return cart;
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public void AddDiscound(long id, string couponHash)
        {
            try
            {
                var shoppingCard = GetById(id);
                if (shoppingCard != null)
                {
                    shoppingCard.TourCoupon = couponHash;
                    _dbContext.Update(shoppingCard);
                    _dbContext.SaveChanges();
                }
            }catch(Exception ex)
            {
                throw new DbUpdateException(ex.Message);
            }
        }

        public void Update(ShoppingCart cart)
        {
            try
            {
                _dbContext.Update(cart);
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                throw new DbUpdateException(e.Message);
            }
        }
    }
}
