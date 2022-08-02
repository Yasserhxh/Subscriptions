using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Commands.SetDefaultPlan.Persistence;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;

namespace Subscriptions.Application.Commands.SetDefaultPlan
{
    public class SetDefaultPlanCommandHandler : IRequestHandler<SetDefaultPlanCommand>
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly ISetDefaultPlanCommandPersistence _persistence;


        public SetDefaultPlanCommandHandler(IUnitOfWorkContext unitOfWorkContext,ISetDefaultPlanCommandPersistence persistence
        )
        {
            _unitOfWorkContext = unitOfWorkContext;
            _persistence = persistence;
        }

        public async Task<Unit> Handle(SetDefaultPlanCommand request, CancellationToken cancellationToken)
        {
            if (!request.AppId.HasValue)
            {
                throw new InvalidOperationException();
            }

            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {
                if (await _persistence.PlanExist(request.PlanName))
                {
                    throw new NotFoundException("");
                }
                await _persistence.SetDefaultPlan(request.PlanName);
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