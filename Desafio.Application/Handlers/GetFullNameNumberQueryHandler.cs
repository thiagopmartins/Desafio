using Desafio.Application.Queries.Requests;
using MediatR;

namespace Desafio.Application.Handlers
{
    public class GetFullNameNumberQueryHandler : IRequestHandler<GetFullNameNumberRequest, GetFullNameNumberResponse>
    {
        public Task<GetFullNameNumberResponse> Handle(GetFullNameNumberRequest request, CancellationToken cancellationToken)
        {
            var result = new GetFullNameNumberResponse
            {
                FullNameNumber = "teste"
            };

            return Task.FromResult(result);
        }
    }
}
