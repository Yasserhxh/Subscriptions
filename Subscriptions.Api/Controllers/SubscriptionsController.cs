using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscriptions.Application.Commands.CreateSubscription;

namespace Subscriptions.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubscriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> CreateSubscription(CreateSubscriptionCommand cmd)
        {
            var res= await _mediator.Send(cmd);
            return Ok();
        }
    }
}