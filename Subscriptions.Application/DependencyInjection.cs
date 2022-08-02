using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Services;

namespace Subscriptions.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddSingleton<IAppSecretGenerator, AppSecretGenerator>();
        }
    }
}