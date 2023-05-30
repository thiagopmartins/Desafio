using Desafio.Application.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArraySumController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArraySumController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("")]
        public async Task<IActionResult> Get([FromBody] ArraySumRequest numbers)
        {           
            var result = await _mediator.Send(numbers);

            return Ok(result);
        }
    }
}
