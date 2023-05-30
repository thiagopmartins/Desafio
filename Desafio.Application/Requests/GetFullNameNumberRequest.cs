using Desafio.Application.Responses;
using MediatR;

namespace Desafio.Application.Requests
{
    public class GetFullNameNumberRequest : IRequest<GetFullNameNumberResponse>
    {
        public int Number { get; set; }
    }
}
