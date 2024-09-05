using Explorer.Payments.API.Dtos;
using FluentResults;

namespace Explorer.Payments.API.Public.PaymentRecord
{
    public interface IPaymentRecordService
    {
        Result<PaymentRecordDto> CreateRecord(long touristId, long bundleId, double amount);
    }
}
