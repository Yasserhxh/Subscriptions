using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Commands.TransformInfiniteTimelineIntroFinite.Persistence;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.TransformInfiniteTimelineIntroFinite
{
    public class TransformInfiniteTimelineIntoFiniteCommandHandler : IRequestHandler<TransformInfiniteTimelineIntoFiniteCommand,TransformInfiniteTimelineIntoFiniteResponse>
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly ITransformInfiniteTimelineIntoFinitePersistence _persistence;

        public TransformInfiniteTimelineIntoFiniteCommandHandler(IUnitOfWorkContext unitOfWorkContext,ITransformInfiniteTimelineIntoFinitePersistence persistence)
        {
            _unitOfWorkContext = unitOfWorkContext;
            _persistence = persistence;
        }

        public async Task<TransformInfiniteTimelineIntoFiniteResponse> Handle(TransformInfiniteTimelineIntoFiniteCommand request, CancellationToken cancellationToken)
        {
            // app owner 
            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {
                var timeLine = await _persistence.GetTimeline(request.TimelineId);
                if (timeLine is null)
                {
                    throw new NotFoundException("");
                }
                    
                if (timeLine is not IInfiniteTimeLine)
                {
                    throw new BadRequestException("");
                }
                var now = DateTime.Now;
                await _persistence.SetTimeLineEnd(request.TimelineId, now);
                await unitOfWork.CommitWork();
                return new TransformInfiniteTimelineIntoFiniteResponse();
            }
            catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}