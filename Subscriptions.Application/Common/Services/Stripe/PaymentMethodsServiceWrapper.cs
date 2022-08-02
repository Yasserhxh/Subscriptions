using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Subscriptions.Application.Common.Services.Stripe.Interfaces;

namespace Subscriptions.Application.Common.Services.Stripe
{
    public class PaymentMethodsServiceWrapper : IPaymentMethodsService
    {
        private PaymentMethodService _paymentMethodService;

        public PaymentMethodsServiceWrapper()
        {
            _paymentMethodService= new PaymentMethodService();
        }

        public async Task<PaymentMethod> GetAsync(string id,PaymentMethodGetOptions options = null,RequestOptions requestOptions = null,CancellationToken cancellationToken = default)
        {
            return await _paymentMethodService.GetAsync(id, options, requestOptions, cancellationToken);
        }
    }
}