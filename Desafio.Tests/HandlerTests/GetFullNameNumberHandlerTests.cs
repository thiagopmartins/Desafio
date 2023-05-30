using Desafio.Application.Handlers;
using Desafio.Application.Requests;

namespace Desafio.Tests.HandlerTests
{
    [TestClass]
    public class GetFullNameNumberHandlerTests
    {
        [TestMethod]
        public void Dada_uma_requisicao_valida_deve_finalizar_com_sucesso()
        {
            GetFullNameNumberRequest request = new GetFullNameNumberRequest
            {
                Number = 1003
            };

            string expectedResult = "Um mil e três";

            var handler = new GetFullNameNumberHandler();

            var result = handler.Handle(request, CancellationToken.None).Result;

            Assert.AreEqual(result.FullNameNumber, expectedResult, true);
        }

        [TestMethod]
        public void Dada_uma_requisicao_valida_deve_retornar_milhoes_no_plural_com_sucesso()
        {
            GetFullNameNumberRequest request = new GetFullNameNumberRequest
            {
                Number = 999999999
            };

            string expectedResult = "Novecentos e noventa e nove milhões e novecentos e noventa e nove mil e novecentos e noventa e nove";

            var handler = new GetFullNameNumberHandler();

            var result = handler.Handle(request, CancellationToken.None).Result;

            Assert.AreEqual(result.FullNameNumber, expectedResult, true);
        }

        [TestMethod]
        public void Dada_uma_requisicao_valida_deve_retornar_milhao_no_singular_com_sucesso()
        {
            GetFullNameNumberRequest request = new GetFullNameNumberRequest
            {
                Number = 1000001
            };

            string expectedResult = "Um milhão e um";

            var handler = new GetFullNameNumberHandler();

            var result = handler.Handle(request, CancellationToken.None).Result;

            Assert.AreEqual(result.FullNameNumber, expectedResult, true);
        }
    }
}
