using System;
using System.Threading.Tasks;
using Core.IntegrationEvents.IntegrationEvents;
using Core.IntegrationEvents.IntegrationEvents.Factories;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Payments.Controllers
{
    [Route("api/v1")]
    public class PaymentsController : Controller
    {
        private readonly IBusControl _bus;
        private ILogger<PaymentsController> _logger;

        public PaymentsController(IBusControl bus, ILogger<PaymentsController> logger)
        {
            _bus = bus;
            _logger = logger;
        }

        [HttpPost, Route("payments")]
        public async Task<IActionResult> ProcessPayment()
        {
            //Domain process
            
            var paymentId = Guid.NewGuid();
            
            await _bus.Publish<PaymentCreated>(PaymentFactory.Created(paymentId, "José", "jose@fakemail.com", 100));
            _logger.LogInformation($"Payment id: {paymentId} created message published!");


            return Ok();
        }
        
    }
}