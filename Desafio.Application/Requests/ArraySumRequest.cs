using Desafio.Application.Responses;
using MediatR;

namespace Desafio.Application.Requests
{
    public class ArraySumRequest : IRequest<ArraySumResponse>
    {
        public int[] Numbers { get; set; }
    }
}
