using System;
using System.Collections.Generic;

namespace Subscriptions.Domain.Common
{
    public class DateTimeRange : ValueObject
    {
        public DateTimeRange(DateTime start, DateTime? end)
        {
            Start = start;
            End = end;
        }

        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return End;
        }

        public bool Contains(DateTime dateTime)
        {
            if (End is null && dateTime >=Start)
            {
                return true;
            }
            return dateTime < End && dateTime >= Start;
        }
    }
}