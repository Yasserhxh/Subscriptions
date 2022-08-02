using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Subscriptions.Application.Commands.CreatePlan;
using Subscriptions.Application.Commands.CreatePlan.Persistence;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddPlan
{
    public class CreatePlanCommandHandler : IRequestHandler<CreatePlanCommand,CreatePlanCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IAddPlanCommandPersistence _persistence;
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public CreatePlanCommandHandler(IMapper mapper, 
            IAddPlanCommandPersistence persistence,
            IUnitOfWorkContext unitOfWorkContext
            )
        {
            _mapper = mapper;
            _persistence = persistence;
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<CreatePlanCommandResponse> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {


                var plan = new Plan();
                _mapper.Map(request, plan);
                await _persistence.AddPlan(plan);
                await unitOfWork.CommitWork();
                return new CreatePlanCommandResponse();
            }
            catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}