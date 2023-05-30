using Desafio.Application.Responses;
using MediatR;

namespace Desafio.Application.Requests
{
    public class DistinctElementsRequest : IRequest<DistinctElementsResponse>
    {
        public List<string> Elements { get; set; }
    }
}
