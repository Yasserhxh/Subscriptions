using System;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.Mediator;
using Subscriptions.Contracts;

namespace Subscriptions.Consumers
{
    public class AddSubscriberConsumer : IConsumer<AddSubscriberMessage>
    {

        public AddSubscriberConsumer()
        {
        }

        public async Task Consume(ConsumeContext<AddSubscriberMessage> context)
        {
            
            Console.WriteLine("Hello");
        }
    }
}