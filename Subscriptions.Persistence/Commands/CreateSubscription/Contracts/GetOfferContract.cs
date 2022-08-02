using NodaTime;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Persistence.Commands.CreateSubscription.Contracts
{
    public class GetOfferContract
    {

        public Period Period { get; set; }
        public decimal? Amount { get; set; }
        public bool? AutoCharging { get; set; }
        public int? Repeat { get; set; }
        public TimelineDefinitionType Discriminator { get; set; }
    }
}