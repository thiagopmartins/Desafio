using Desafio.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistinctElementsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DistinctElementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Get([FromBody] DistinctElementsRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
