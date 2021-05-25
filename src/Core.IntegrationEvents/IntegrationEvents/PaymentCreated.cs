using System;

namespace Core.IntegrationEvents.IntegrationEvents
{
    public interface PaymentCreated : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Amount { get; set; }
    }
}