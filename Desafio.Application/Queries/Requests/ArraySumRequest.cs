using Desafio.Application.Queries.Responses;
using MediatR;

namespace Desafio.Application.Queries.Requests
{
    public class ArraySumRequest : IRequest<ArraySumResponse>
    {
        public int[] Numbers { get; set; }
    }
}
