using Desafio.Application.Queries.Requests;
using Desafio.Application.Queries.Responses;
using MediatR;

namespace Desafio.Application.Handlers
{
    public class ArraySumHandler : IRequestHandler<ArraySumRequest, ArraySumResponse>
    {
        public Task<ArraySumResponse> Handle(ArraySumRequest request, CancellationToken cancellationToken)
        {
            ArraySumResponse result = new ArraySumResponse
            {
                Sum = request.Numbers.Sum()
            };

            return Task.FromResult(result);
        }
    }
}
