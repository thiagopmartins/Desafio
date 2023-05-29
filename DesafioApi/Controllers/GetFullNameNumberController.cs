using Desafio.Application.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFullNameNumberController : BaseApiController
    {
        private readonly IMediator _mediator;

        public GetFullNameNumberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> Get(int number)
        {
            var request = new GetFullNameNumberRequest
            {
                Number = number
            };

            var result = await _mediator.Send(request);

            return Ok(result);
        }
    }
}
