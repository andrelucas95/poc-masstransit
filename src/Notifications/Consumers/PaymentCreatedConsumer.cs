using System;
using System.Threading.Tasks;
using Core.IntegrationEvents.IntegrationEvents;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Notifications.Consumers
{
    public class PaymentCreatedConsumer : IConsumer<PaymentCreated>
    {
        private ILogger<PaymentCreatedConsumer> _logger;

        public PaymentCreatedConsumer(ILogger<PaymentCreatedConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PaymentCreated> context)
        {
            try
            {
                var payment = context.Message;
                _logger.LogInformation($"Payment id: {payment.Id} created message received!");
                
                // Send email notification
            }
            catch(Exception ex)
            {
                _logger.LogError("Error on consume payment created", ex);
                throw;
            }
            
            return Task.CompletedTask;
        }
    }
}