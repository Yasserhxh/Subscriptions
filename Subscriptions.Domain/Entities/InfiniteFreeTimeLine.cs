using System;
using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public class InfiniteFreeTimeLine : FreeTimeLine,IInfiniteTimeLine
    {
        public override bool IsValid(DateTime date)
        {
            return DateTimeRange.Contains(date);
        }

        public InfiniteFreeTimeLine(DateTime start) : base(new DateTimeRange(start,null))
        {
            TimelineType = TimelineType.InfiniteFreeTimeline;
        }

        public void MakeItFinite(DateTime end)
        {
            DateTimeRange = new DateTimeRange(DateTimeRange.Start, end);
        }
    }
}