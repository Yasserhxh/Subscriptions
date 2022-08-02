
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions
{
    public class TimelineDefinitionDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public int Order { get; set; }
        public bool Finite { get; set; }
        public bool Paid { get; set; }
        public string Expiration { get; set; }
        public decimal? Amount { get; set; }
        public int? Repeat { get; set; }
        public bool? AutoCharging { get; set; }
        public string Type { get; set; }
        public TimelineDefinitionType Discriminator { get; set; }
    }
}