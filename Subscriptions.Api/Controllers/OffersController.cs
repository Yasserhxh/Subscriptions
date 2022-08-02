using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscriptions.Application.Commands.AddOfferToPlan;
using Subscriptions.Application.Queries.Offers.GetOffer;

namespace Subscriptions.Api.Controllers
{
    [ApiController]
    [Route("/plans/{planId:required:long}/offers")]
    public class OffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddOffer(AddOfferToPlanCommand cmd)
        {
            var res = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetOffer),new {res.Id});
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOffer(GetOfferQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpGet("{id}/definitions")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOfferTimelinesDefinitions(GetOfferQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
    }
}