using Desafio.Application.Requests;
using Desafio.Application.Responses;
using MediatR;

namespace Desafio.Application.Handlers
{
    public class ArraySumHandler : IRequestHandler<ArraySumRequest, ArraySumResponse>
    {
        public Task<ArraySumResponse> Handle(ArraySumRequest request, CancellationToken cancellationToken)
        {
            ArraySumResponse result = new ArraySumResponse
            {
                Sum = request.Numbers.Sum(x => (long)x)
            };

            return Task.FromResult(result);
        }
    }
}
