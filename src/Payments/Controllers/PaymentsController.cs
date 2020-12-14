using System.Threading.Tasks;
using Core.IntegrationEvents.IntegrationEvents;
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
            var payment = new PaymentCreated("José", "jose@fakemail.com", 100);
            
            await _bus.Publish<PaymentCreated>(payment);
            _logger.LogInformation($"Payment {payment.Id} created");


            return Ok();
        }
        
    }
}