using System;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class InfinitePaidTimeLine : PaidTimeLine,IInfiniteTimeLine
    {
        public InfinitePaidTimeLine(DateTime start,decimal amount,bool paid = false,bool autoCharging = false) : base(new DateTimeRange(start,null),amount, paid, autoCharging)
        {
            TimelineType = TimelineType.InfinitePaidTimeline;
            Amount = amount;
            Paid = paid;
            AutoCharging = autoCharging;
        }


        public void MakeItFinite(DateTime end)
        {
            DateTimeRange = new DateTimeRange(DateTimeRange.Start, end);
        }
    }
}