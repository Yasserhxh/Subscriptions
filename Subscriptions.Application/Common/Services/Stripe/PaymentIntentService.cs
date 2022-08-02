using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Subscriptions.Application.Common.Services.Stripe.Interfaces;

namespace Subscriptions.Application.Common.Services.Stripe
{
    public class PaymentIntentServiceWrapper : IPaymentIntentService
    {
        private readonly PaymentIntentService _paymentIntentService;

        public PaymentIntentServiceWrapper()
        {
            _paymentIntentService = new PaymentIntentService();
        }

        public async Task<PaymentIntent> CreateAsync(PaymentIntentCreateOptions paymentIntentCreateOptions,RequestOptions requestOptions = null,CancellationToken cancellationToken = default)
        {
            return await _paymentIntentService.CreateAsync(paymentIntentCreateOptions,requestOptions,cancellationToken);
        }
    }
}