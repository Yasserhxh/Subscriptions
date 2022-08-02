using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Services.Stripe.Interfaces;
using PaymentMethod = Subscriptions.Domain.Entities.PaymentMethod;

namespace Subscriptions.Infrastructure.Stripe
{
    public class PaymentMethodsService : IPaymentMethodsService
    {

        public Task<global::Stripe.PaymentMethod> GetAsync(string id, PaymentMethodGetOptions options = null, RequestOptions requestOptions = null,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}