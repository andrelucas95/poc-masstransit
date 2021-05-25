using System;

namespace Core.IntegrationEvents.IntegrationEvents.Factories
{
    public static class PaymentFactory
    {
        public static object Created(Guid id, string customerName, string customerEmail, decimal amount)
        {
            return new
            {
                Id = id,
                CustomerName = customerName,
                CustomerEmail = customerEmail,
                Amount = amount
            };
        }
    }
}