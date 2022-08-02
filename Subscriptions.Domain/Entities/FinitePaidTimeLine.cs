using System;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class FinitePaidTimeLine : PaidTimeLine
    {

        
        public FinitePaidTimeLine(DateTimeRange dateTimeRange,decimal amount,bool paid = false,bool autoCharging = false) : base(dateTimeRange,amount,paid , autoCharging)
        {
            TimelineType = TimelineType.FinitePaidTimeline;
        }

     
    }
}