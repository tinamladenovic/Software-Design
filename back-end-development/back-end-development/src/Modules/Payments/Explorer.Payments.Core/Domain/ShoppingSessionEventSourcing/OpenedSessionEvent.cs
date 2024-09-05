using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing
{
    public class OpenedSessionEvent: DomainEvent
    {

        [JsonConstructor]
        public OpenedSessionEvent(long aggregateId, DateTime eventTime,string context) : base(aggregateId,eventTime,context)
        {
            EventTime = eventTime;
            Context = "Kreirana shopping sesija";
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
