namespace Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing
{
    using Explorer.BuildingBlocks.Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    public class RemovingTourBundleEvent : DomainEvent
    {
        [JsonConstructor]
        public RemovingTourBundleEvent(long aggregateId, DateTime eventTime, string context) : base(aggregateId, eventTime, context)
        {
            EventTime = eventTime;
            Context = "Bundle tura je obrisana iz korpe!";
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
