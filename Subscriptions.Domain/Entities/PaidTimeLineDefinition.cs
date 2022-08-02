using System;

namespace Subscriptions.Domain.Entities
{
    public abstract class PaidTimeLineDefinition : TimeLineDefinition
    {
        public decimal Amount { get; set; }
        public bool AutoCharging { get; set; }
    }
}