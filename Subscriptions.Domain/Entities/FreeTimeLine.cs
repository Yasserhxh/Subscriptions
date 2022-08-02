using Subscriptions.Domain.Common;

namespace Subscriptions.Domain.Entities
{
    public abstract class FreeTimeLine : TimeLine
    {
        protected FreeTimeLine(DateTimeRange dateTimeRange) : base(dateTimeRange)
        {
            
        }
    }
}