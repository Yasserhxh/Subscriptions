using System.Threading;
using System.Threading.Tasks;
using Stripe;

namespace Subscriptions.Application.Common.Services.Stripe.Interfaces
{
    public interface IPaymentMethodsService
    {
        Task<PaymentMethod> GetAsync(string id, PaymentMethodGetOptions options = null, RequestOptions requestOptions = null, CancellationToken cancellationToken = default);

    }
}