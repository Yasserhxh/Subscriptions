using System;

namespace Subscriptions.Domain.Entities
{
    public interface IInfiniteTimeLine
    {

        public void MakeItFinite(DateTime end);
    }
}