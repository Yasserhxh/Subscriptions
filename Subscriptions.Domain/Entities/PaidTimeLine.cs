using System;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public abstract class PaidTimeLine : TimeLine
    {
        public bool Paid { get; set; }
        public decimal Amount { get; set; }
        public bool AutoCharging { get; set; }


        protected PaidTimeLine(DateTimeRange dateTimeRange, decimal amount, bool paid, bool autoCharging) : base(dateTimeRange)
        {
            Amount = amount;
            Paid = paid;
            AutoCharging = autoCharging;
        }

        public override bool IsValid(DateTime date)
        {
            return DateTimeRange.Contains(date) && Paid;
        }
    }
}