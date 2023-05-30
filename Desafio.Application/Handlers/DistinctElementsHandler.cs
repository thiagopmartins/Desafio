using Desafio.Application.Requests;
using Desafio.Application.Responses;
using MediatR;

namespace Desafio.Application.Handlers
{
    public class DistinctElementsHandler :
        IRequestHandler<DistinctElementsRequest, DistinctElementsResponse>
    {
        public Task<DistinctElementsResponse> Handle(DistinctElementsRequest request, CancellationToken cancellationToken)
        {
            DistinctElementsResponse result = new DistinctElementsResponse
            {
                Elements = request.Elements.Distinct().ToList()
            };

            return Task.FromResult(result);
        }
    }
}
