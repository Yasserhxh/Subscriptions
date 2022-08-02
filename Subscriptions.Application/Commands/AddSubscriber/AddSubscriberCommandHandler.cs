using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Commands.AddSubscriber.Persistence;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddSubscriber
{
    public class AddSubscriberCommandHandler : IRequestHandler<AddSubscriberCommand>
    {
        private readonly IUnitOfWorkContext _unitOfWorkContext;
        private readonly IAddSubscriberPersistence _persistence;

        public AddSubscriberCommandHandler(IUnitOfWorkContext  unitOfWorkContext,IAddSubscriberPersistence persistence)
        {
            _unitOfWorkContext = unitOfWorkContext;
            _persistence = persistence;
        }

        public async Task<Unit> Handle(AddSubscriberCommand request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {
                var subscriber = new Subscriber()
                {
                    Id = request.Id,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                };
                await _persistence.AddSubscriber(subscriber);
            }
            catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }

            
            return Unit.Value;
        }
    }
}