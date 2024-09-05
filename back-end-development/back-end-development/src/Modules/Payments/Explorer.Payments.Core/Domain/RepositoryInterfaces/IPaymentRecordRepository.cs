using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.RepositoryInterfaces
{
    public interface IPaymentRecordRepository
    {
        PaymentRecord Create(PaymentRecord paymentRecord);
        PaymentRecord Get(long id);
    }
}
