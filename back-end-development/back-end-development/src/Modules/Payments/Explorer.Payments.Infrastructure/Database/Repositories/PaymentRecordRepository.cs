using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Explorer.Payments.Infrastructure.Database.Repositories
{
    public class PaymentRecordRepository : IPaymentRecordRepository
    {
        private readonly PaymentsContext _dbContext;
        private readonly DbSet<PaymentRecord> _dbSet;

        public PaymentRecordRepository(PaymentsContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<PaymentRecord>();
        }
        public PaymentRecord Create(PaymentRecord paymentRecord)
        {
            try
            {
                _dbSet.Add(paymentRecord);
                _dbContext.SaveChanges();
                return paymentRecord;
            }
            catch (Exception e)
            {
                throw new DbUpdateException(e.Message);
            }
        }

        public PaymentRecord Get(long id)
        {
            var entity = _dbSet.AsNoTracking().FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException("Not found: " + id);
            }

            return entity;
        }
    }
}
