using Desafio.Application.Responses;
using MediatR;

namespace Desafio.Application.Requests
{
    public class CalculateMathFunctionRequest : IRequest<CalculateMathFunctionResponse>
    {
        public string Function { get; set; }
    }
}
