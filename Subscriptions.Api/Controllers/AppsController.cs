using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Subscriptions.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AppsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppsController(IMediator mediator)
        {
            _mediator = mediator;
        }

  
     
        
    }
}