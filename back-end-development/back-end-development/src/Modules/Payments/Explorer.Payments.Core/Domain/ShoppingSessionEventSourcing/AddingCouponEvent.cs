using Explorer.BuildingBlocks.Core.Domain;
using Newtonsoft.Json;

namespace Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing
{
    public class AddingCouponEvent : DomainEvent
    {
        [JsonConstructor]
        public AddingCouponEvent(long aggregateId, DateTime eventTime, string context) : base(aggregateId, eventTime, context)
        {
            EventTime = eventTime;
            Context = "Dodat je kupon za popust!";
        }

        public DateTime EventTime { get; private set; }
        public string Context { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {

            yield return EventTime;
            yield return Context;

        }
    }
}
