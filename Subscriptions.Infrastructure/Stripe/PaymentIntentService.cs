using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Subscriptions.Application.Common.Services.Stripe.Interfaces;

namespace Subscriptions.Infrastructure.Stripe
{
    public class PaymentIntentService : IPaymentIntentService
    {
        public Task<PaymentIntent> CreateAsync(PaymentIntentCreateOptions paymentIntentCreateOptions, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}