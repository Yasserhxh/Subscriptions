using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscriptions.Application.Commands.AddPlan;
using Subscriptions.Application.Commands.CreatePlan;
using Subscriptions.Application.Commands.UpdatePlan;
using Subscriptions.Application.Queries.Plans.GetPlans;

namespace Subscriptions.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlan(GetPlanQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlan(CreatePlanCommand cmd)
        {
            var res = await _mediator.Send(cmd);
            return CreatedAtAction(nameof(GetPlan),new {id = res.Id });
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlan(UpdatePlanCommand cmd)
        {
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }
    }
}