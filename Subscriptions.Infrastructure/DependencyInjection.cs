using System.Data.SqlClient;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Services.Stripe.Interfaces;
using Subscriptions.Consumers;
using Subscriptions.Infrastructure.Stripe;

namespace Subscriptions.Infrastructure
{
    public static class DependencyInjection
    {
        public  static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,IConfiguration configuration)
        {

            serviceCollection.AddScoped<IPaymentIntentService, PaymentIntentService>();
            serviceCollection.AddScoped<IPaymentMethodsService, PaymentMethodsService>();
            serviceCollection.AddMassTransit(cfg =>
            {
                cfg.AddConsumer<AddSubscriberConsumer>();
                cfg.UsingAzureServiceBus(((context, configurator) =>
                {
                    configurator.Host("Endpoint=sb://subpay.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=/yJlbRI8nb3qbdKYmTtkklot6+uqEjoxhWOercA7LCE=");
                    configurator.ReceiveEndpoint("add-subscriber-queue",(endpointConfigurator =>
                    {
                        endpointConfigurator.ConfigureConsumeTopology = false;
                        endpointConfigurator.ConfigureConsumer<AddSubscriberConsumer>(context);
                        endpointConfigurator.UseRawJsonSerializer();
                    }));
                }));
            });
            serviceCollection.AddMassTransitHostedService();

            return serviceCollection;
        }
    }
}