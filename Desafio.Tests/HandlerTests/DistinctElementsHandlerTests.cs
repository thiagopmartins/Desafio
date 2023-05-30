using Desafio.Application.Handlers;
using Desafio.Application.Requests;

namespace Desafio.Tests.HandlerTests
{
    [TestClass]
    public class DistinctElementsHandlerTests
    {
        [TestMethod]
        public void Dada_uma_requisicao_valida_deve_retornar_valores_unicos_com_sucesso()
        {
            DistinctElementsRequest request = new DistinctElementsRequest
            {
                Elements = new List<string> { "deve", "retornar", "valores", "unicos", "unicos", "valores" }
            };            

            var handler = new DistinctElementsHandler();

            var result = handler.Handle(request, CancellationToken.None).Result;

            Assert.AreEqual(result.Elements.Count(), 4);
        }        
    }
}
