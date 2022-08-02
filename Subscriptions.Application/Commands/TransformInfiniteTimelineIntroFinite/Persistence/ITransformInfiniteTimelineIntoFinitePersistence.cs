using System;
using System.Threading.Tasks;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.TransformInfiniteTimelineIntroFinite.Persistence
{
    public interface ITransformInfiniteTimelineIntoFinitePersistence
    {
        Task<TimeLine> GetTimeline(string id);
        Task SetTimeLineEnd(string id, DateTime now);
    }
}