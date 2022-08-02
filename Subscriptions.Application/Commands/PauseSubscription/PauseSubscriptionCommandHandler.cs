using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Commands.PauseSubscription.Persistence;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.PauseSubscription
{
    public class PauseSubscriptionCommandHandler : IRequestHandler<PauseSubscriptionCommand,PauseSubscriptionCommandResponse>
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly IPauseSubscriptionCommandPersistence _persistence;

        public PauseSubscriptionCommandHandler(IUnitOfWorkContext unitOfWorkContext,IPauseSubscriptionCommandPersistence persistence)
        {
            _unitOfWorkContext = unitOfWorkContext;
            _persistence = persistence;
        }

        public async Task<PauseSubscriptionCommandResponse> Handle(PauseSubscriptionCommand request, CancellationToken cancellationToken)
        {
            //subscription owner or admin are allowed
            await using (var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork())
            {
                await unitOfWork.BeginWork();
                try
                {
                    var subscription = await _persistence.GetSubscription(request.SubscriptionId);
                    if (subscription is null)
                    {
                        throw new NotFoundException("");
                    }
                    
                    if (!subscription.IsActive())
                    {
                        throw new BadRequestException("you can pause only active subscription");
                    }
                    
                    await _persistence.SetStatus(SubscriptionStatus.Paused);
                    await unitOfWork.CommitWork();
                    return new PauseSubscriptionCommandResponse();
                }
                catch (Exception)
                {
                    await unitOfWork.RollBack();
                    throw;
                }
            }
        }
    }
}