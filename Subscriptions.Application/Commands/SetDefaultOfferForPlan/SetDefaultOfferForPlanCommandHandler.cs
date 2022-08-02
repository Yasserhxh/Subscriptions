using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;

namespace Subscriptions.Application.Commands.SetDefaultOfferForPlan
{
    public class SetDefaultOfferForPlanCommandHandler : IRequestHandler<SetDefaultOfferForPlanCommand>
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public SetDefaultOfferForPlanCommandHandler(IUnitOfWorkContext unitOfWorkContext)
        {
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<Unit> Handle(SetDefaultOfferForPlanCommand request, CancellationToken cancellationToken)
        {
            if (!request.AppId.HasValue)
            {
                throw new InvalidOperationException();
            }
            await using (var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork())
            {
                await unitOfWork.BeginWork();
                try
                {
                    // if (await _plansRepository.Exist(request.AppId.Value,request.PlanName))
                    // {
                    //     throw new NotFoundException("");
                    // }
                    // await _plansRepository.SetDefaultOffer(request.AppId.Value,request.PlanName,request.OfferName);
                    await unitOfWork.CommitWork();
                    return Unit.Value;
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