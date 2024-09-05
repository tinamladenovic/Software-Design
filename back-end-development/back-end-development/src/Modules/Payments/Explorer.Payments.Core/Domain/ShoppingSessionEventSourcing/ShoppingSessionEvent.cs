using Explorer.BuildingBlocks.Core.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Payments.Core.Domain.ShoppingSessionEventSourcing
{
    public class ShoppingSessionEvent : EventSourcedAggregate
    {
        public long AggregateId { get; set; }
        public DateTime TimeStamp { get; set; }

        public Boolean isActive { get; set; }
       

        public ShoppingSessionEvent() { }

        public ShoppingSessionEvent(long aggregateId, DateTime timeStamp, Boolean isActive)
        {
            this.AggregateId = aggregateId;
            TimeStamp = timeStamp;
            this.isActive = isActive;

        }



        public override void Apply(DomainEvent @event)
        {
            When((dynamic)@event);
            Version = Version++;
        }

        private void Causes(DomainEvent @event)
        {
            Changes.Add(@event);
            Apply(@event);
        }

        public void CreateSession(long aggregateId)
        {
            Causes(new OpenedSessionEvent(aggregateId, DateTime.UtcNow,""));
        }
        
        public void AddTour(long aggregateId)
        {
            Causes(new AddingTourEvent(aggregateId, DateTime.UtcNow,""));
        }

        public void AddTourBundle(long aggregateId)
        {
            Causes(new AddingTourBundleEvent(aggregateId, DateTime.UtcNow, ""));
        }

        public void AddCoupon(long aggregateId)
        {
            Causes(new AddingCouponEvent(aggregateId, DateTime.UtcNow, ""));
        }

        public void RemoveTour(long aggregateId)
        {
            Causes(new RemovingTourEvent(aggregateId, DateTime.UtcNow, ""));
        }

        public void RemoveTourBundle(long aggregateId)
        {
            Causes(new RemovingTourBundleEvent(aggregateId, DateTime.UtcNow, ""));
        }

        public void CloseSession(long aggregateId)
        {
            Causes(new CheckoutEvent(aggregateId, DateTime.UtcNow, ""));
        }


        private void When(OpenedSessionEvent openedSession)
        {
            return;
        }

        private void When(AddingTourEvent addingTourEvent)
        {
            return;
        }

        private void When(AddingTourBundleEvent addingTourBundleEvent)
        {
            return;
        }

        private void When(RemovingTourEvent removingTourEvent)
        {
            return;
        }


        private void When(RemovingTourBundleEvent removingTourBundleEvent)
        {
            return;
        }

        private void When(CheckoutEvent checkoutEvent)
        {
            return;
        }

        private void When(AddingCouponEvent checkoutEvent)
        {
            return;
        }

        /*        private void When(DomainEvent checkoutEvent)
                {
                    return;
                }*/



    }
}
