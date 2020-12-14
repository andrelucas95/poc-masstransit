using System;

namespace Core.IntegrationEvents.IntegrationEvents
{
    public class PaymentCreated : IntegrationEvent
    {
        public PaymentCreated(string customerName, string customerEmail, decimal amount)
        {
            Id = Guid.NewGuid();
            CustomerName = CustomerName;
            CustomerEmail = CustomerEmail;
            Amount = amount;
        }

        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public decimal Amount { get; set; }
    }
}