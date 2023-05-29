using MediatR;

namespace Desafio.Api.Extensions
{
    public static class Mediator
    {
        public static void AddMediator(this IServiceCollection service)
        {
            var assembly = AppDomain.CurrentDomain.Load("Desafio.Application");
            service.AddMediatR(assembly);
        }
    }
}
