using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Subscriptions.Application.Commands.AddOfferToPlan.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Persistence;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddOfferToPlan
{
    public class AddOfferToPlanCommandHandler : IRequestHandler<AddOfferToPlanCommand,AddOfferToPlanCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly IAddOfferToPlanCommandPersistence _addOfferToPlanCommandPersistence;
        private readonly IPlansPersistence _plansPersistence;

        public AddOfferToPlanCommandHandler(IMapper mapper
            , IUnitOfWorkContext unitOfWorkContext
            ,IAddOfferToPlanCommandPersistence addOfferToPlanCommandPersistence,IPlansPersistence plansPersistence)
        {
            _mapper = mapper;
            _unitOfWorkContext = unitOfWorkContext;
            _addOfferToPlanCommandPersistence = addOfferToPlanCommandPersistence;
            _plansPersistence = plansPersistence;
        }

        public async Task<AddOfferToPlanCommandResponse> Handle(AddOfferToPlanCommand request, CancellationToken cancellationToken)
        {

            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {

                if (await _plansPersistence.PlanExist(request.PlanId))
                {
                    throw new InvalidOperationException();
                }
                var offer = new Offer();
                _mapper.Map(request,offer);
                await _addOfferToPlanCommandPersistence.AddOffer(request.PlanId,offer);
                await unitOfWork.CommitWork();
                return new AddOfferToPlanCommandResponse();
            }
            catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}