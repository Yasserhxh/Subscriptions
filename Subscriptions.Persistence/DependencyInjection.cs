using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Subscriptions.Application.Commands.AddFeatureToPlan.Persistence;
using Subscriptions.Application.Commands.AddOfferToPlan.Persistence;
using Subscriptions.Application.Commands.AddSubscriber.Persistence;
using Subscriptions.Application.Commands.CreatePlan.Persistence;
using Subscriptions.Application.Commands.CreateSubscription.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Persistence;
using Subscriptions.Application.Queries.Offers.GetOffer.Persistence;
using Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions.Persistence;
using Subscriptions.Persistence.Commands.AddFeatureToPlan;
using Subscriptions.Persistence.Commands.AddOffer;
using Subscriptions.Persistence.Commands.AddPlan;
using Subscriptions.Persistence.Commands.AddSubscriber;
using Subscriptions.Persistence.Commands.CreateSubscription;
using Subscriptions.Persistence.Common;
using Subscriptions.Persistence.Queries.Offers.GetOffer;
using Subscriptions.Persistence.Queries.Offers.GetTimelinesDefinitions;

namespace Subscriptions.Persistence
{
    public static class DependencyInjection
    {
        public  static IServiceCollection AddPersistence(this IServiceCollection serviceCollection,IConfiguration configuration)
        {
            serviceCollection.AddScoped(_ =>
            {
                var conStr = configuration.GetConnectionString("Subscriptions_db");
                return new NpgsqlConnection(conStr);
            });
            serviceCollection.AddScoped<IUnitOfWorkContext,UnitOfWorkContext>();

            serviceCollection.AddScoped<IAddOfferToPlanCommandPersistence, AddOfferPersistence>();
            serviceCollection.AddScoped<ICreateSubscriptionCommandPersistence, CreateSubscriptionPersistence>();
            serviceCollection.AddScoped<IAddPlanCommandPersistence, AddPlanPersistence>();
            serviceCollection.AddScoped<IAddFeatureToPlanCommandPersistence,AddFeatureToPlanPersistence>();
            serviceCollection.AddScoped<IAddSubscriberPersistence, AddSubscriberPersistence>();
            serviceCollection.AddScoped<IGetOfferQueryPersistence, GetOfferQueryPersistence>();
            serviceCollection.AddScoped<IGetTimelinesDefinitionsPersistence, GetTimelinesDefinitionsPersistence>();
            serviceCollection.AddScoped<ISubscribersPersistence, SubscribersPersistence>();
            serviceCollection.AddScoped<IPlansPersistence, PlansPersistence>();
            return serviceCollection;
        }
    }
}