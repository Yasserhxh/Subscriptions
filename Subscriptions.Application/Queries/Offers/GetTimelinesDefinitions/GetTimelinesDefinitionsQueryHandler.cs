using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Application.Common.Interfaces;
using Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions.Persistence;
using Subscriptions.Domain.Entities;

namespace Subscriptions.Application.Queries.Offers.GetTimelinesDefinitions
{
    public class GetTimelinesDefinitionsQueryHandler : IRequestHandler<GetTimelinesDefinitionsQuery,GetTimelinesDefinitionsQueryResponse>
    {
        private readonly IGetTimelinesDefinitionsPersistence _getTimelinesDefinitionsPersistence;
        private readonly IUnitOfWorkContext _unitOfWorkContext;

        public GetTimelinesDefinitionsQueryHandler(IGetTimelinesDefinitionsPersistence getTimelinesDefinitionsPersistence,
            IUnitOfWorkContext unitOfWorkContext)
        {
            _getTimelinesDefinitionsPersistence = getTimelinesDefinitionsPersistence;
            _unitOfWorkContext = unitOfWorkContext;
        }

        public async Task<GetTimelinesDefinitionsQueryResponse> Handle(GetTimelinesDefinitionsQuery request, CancellationToken cancellationToken)
        {
            await using var unitOfWork = await _unitOfWorkContext.CreateUnitOfWork();
            await unitOfWork.BeginWork();
            try
            {
                var definitions = await _getTimelinesDefinitionsPersistence.GetTimelinesDefinitions(request.OfferId);
                foreach (var definition in definitions)
                {
                    switch (definition.Discriminator)
                    {
                        case TimelineDefinitionType.FiniteFreeTimeLineDefinition:
                            definition.Finite = true;
                            definition.Paid = false;
                            break;
                        case TimelineDefinitionType.FinitePaidTimeLineDefinition:
                            definition.Finite = true;
                            definition.Paid = true;
                            break;
                        case TimelineDefinitionType.InfinitePaidTimelineDefinition:
                            definition.Finite = false;
                            definition.Paid = true;
                            break;
                        case TimelineDefinitionType.InfiniteFreeTimeLineDefinition:
                            definition.Finite = false;
                            definition.Paid = false;
                            break;
                    }
                }
                return new GetTimelinesDefinitionsQueryResponse()
                {
                    Definitions = definitions
                };
            }catch (Exception)
            {
                await unitOfWork.RollBack();
                throw;
            }
        }
    }
}