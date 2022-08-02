using System.Threading;
using System.Threading.Tasks;
using Stripe;

namespace Subscriptions.Application.Common.Services.Stripe.Interfaces
{
    public interface IPaymentIntentService
    {
        public Task<PaymentIntent> CreateAsync(PaymentIntentCreateOptions paymentIntentCreateOptions,RequestOptions requestOptions = null,CancellationToken cancellationToken = default);
    }
}