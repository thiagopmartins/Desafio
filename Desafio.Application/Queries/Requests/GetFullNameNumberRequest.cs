using MediatR;

namespace Desafio.Application.Queries.Requests
{
    public class GetFullNameNumberRequest : IRequest<GetFullNameNumberResponse>
    {
        public int Number { get; set; }
    }
}
