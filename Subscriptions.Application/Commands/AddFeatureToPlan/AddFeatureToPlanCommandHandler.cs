using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Subscriptions.Application.Commands.AddFeatureToPlan.Persistence;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddFeatureToPlan
{
    public class AddFeatureToPlanCommandHandler : IRequestHandler<AddFeatureToPlanCommand,AddFeatureToPlanResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly IAddFeatureToPlanCommandPersistence _persistence;

        public AddFeatureToPlanCommandHandler(IMapper mapper,IUnitOfWorkContext unitOfWorkContext,IAddFeatureToPlanCommandPersistence persistence)
        {
            _mapper = mapper;
            _unitOfWorkContext = unitOfWorkContext;
            _persistence = persistence;
        }

        public async Task<AddFeatureToPlanResponse> Handle(AddFeatureToPlanCommand request, CancellationToken cancellationToken)
        {

            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {
                if (await _persistence.PlanExist(request.PlanName))
                {
                    throw new NotFoundException(string.Empty);
                }
                var feature = new Feature();
                _mapper.Map(request, feature);
                await _persistence.AddFeatureToPlan(request.PlanName, feature);
                await unitOfWork.CommitWork();
                return new AddFeatureToPlanResponse()
                {
                };
            }
            catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}