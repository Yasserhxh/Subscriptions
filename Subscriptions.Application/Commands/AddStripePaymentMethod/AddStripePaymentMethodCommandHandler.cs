using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Stripe;
using Subscriptions.Application.Common.Exceptions;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Common.Services.Stripe.Interfaces;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Commands.AddStripePaymentMethod
{
    public class AddStripePaymentMethodCommandHandler : IRequestHandler<AddStripePaymentMethodCommand,AddStripePaymentMethodCommandResponse>
    {
        private readonly IPaymentMethodsService _paymentMethodsService;
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public AddStripePaymentMethodCommandHandler(IPaymentMethodsService paymentMethodsService
            ,IUnitOfWorkContext unitOfWorkContext
            )
        {
            _paymentMethodsService = paymentMethodsService;
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<AddStripePaymentMethodCommandResponse> Handle(AddStripePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _paymentMethodsService.GetAsync(request.PaymentMethodId, cancellationToken: cancellationToken);
                await using (var unitOfWork = await  _unitOfWorkContext.CreateUnitOfWork())
                {
                    await unitOfWork.BeginWork();
                    try
                    {
                        // var subscriber = await _subscribersRepository.GetSubscriber(request.SubscriberId);
                        // if (subscriber is null)
                        // {
                        //     throw new NotFoundException("");
                        // }
                        // var stripePaymentMethod =
                        //     new StripePaymentMethod(Guid.NewGuid().ToString(), subscriber, request.PaymentMethodId);
                        // await _paymentMethodsRepository.StorePaymentMethod(stripePaymentMethod);
                        // if (subscriber.DefaultPaymentMethod is null)
                        // {
                        //     subscriber.DefaultPaymentMethod = stripePaymentMethod;
                        // }
                        //
                        // await _subscribersRepository.SetDefaultPaymentMethod(subscriber);
                        await unitOfWork.CommitWork();
                        return new AddStripePaymentMethodCommandResponse();
                    }
                    catch (Exception)
                    {
                        await unitOfWork.RollBack();
                        throw;
                    }    
                }
            }
            catch (StripeException e)
            {
                if (e.HttpStatusCode == HttpStatusCode.NotFound)
                {
                    throw new NotFoundException("no payment method found");
                }
                throw;
            }
        }
    }
}