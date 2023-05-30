using Desafio.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateMathFunctionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalculateMathFunctionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Get([FromBody] CalculateMathFunctionRequest numbers)
        {           
            var result = await _mediator.Send(numbers);

            return Ok(result);
        }
    }
}
