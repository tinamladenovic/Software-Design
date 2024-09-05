using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Payments.API.Dtos;
using Explorer.Payments.API.Public.PaymentRecord;
using Explorer.Payments.Core.Domain;
using Explorer.Payments.Core.Domain.RepositoryInterfaces;
using Explorer.Tours.API.Public.Author;
using FluentResults;

namespace Explorer.Payments.Core.UseCases
{
    public class PaymentRecordService : BaseService<PaymentRecordDto, PaymentRecord>, IPaymentRecordService
    {
        private readonly IPaymentRecordRepository _paymentRecordRepository;
        public PaymentRecordService(IMapper mapper, IPaymentRecordRepository paymentRecordRepository) : base(mapper)
        {
            _paymentRecordRepository = paymentRecordRepository;
        }

        public Result<PaymentRecordDto> CreateRecord(long touristId, long bundleId, double amount)
        {
            var record = new PaymentRecord(touristId, bundleId, amount);
            _paymentRecordRepository.Create(record);
            return MapToDto(record);
        }
    }
}
