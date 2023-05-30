using Desafio.Application.Handlers;
using Desafio.Application.Requests;

namespace Desafio.Tests.HandlerTests
{
    [TestClass]
    public class CalculateMathFunctionHandlerTests
    {
        [TestMethod]
        public void Dada_uma_requisicao_valida_deve_resolver_a_expressao_matematica_com_sucesso()
        {
            CalculateMathFunctionRequest request = new CalculateMathFunctionRequest
            {
                Function = "20 + 1 * 6 / 2 - 10"
            };

            int expectedResult = 13;

            var handler = new CalculateMathFunctionHandler();

            var result = handler.Handle(request, CancellationToken.None).Result;

            Assert.AreEqual(result.Result, expectedResult);
        }

        [TestMethod]
        public void Dada_uma_expressao_que_comeca_com_operador_matematico_deve_retornar_excecao()
        {
            CalculateMathFunctionRequest request = new CalculateMathFunctionRequest
            {
                Function = "+ 1 * 6 / 2 - 10"
            };

            string message = $"Expressão matemática inválida: {request.Function}";

            var handler = new CalculateMathFunctionHandler();

            var exception = Assert.ThrowsException<ArgumentException>(
                () => handler.Handle(request, CancellationToken.None).Result);

            Assert.AreEqual(message, exception.Message, true);
        }

        [TestMethod]
        public void Dada_uma_expressao_que_o_denominador_seja_zero_deve_retornar_excecao()
        {
            CalculateMathFunctionRequest request = new CalculateMathFunctionRequest
            {
                Function = "1 + 1 * 6 / 0 - 10"
            };

            string message = $"Denominador não pode ser '0'";

            var handler = new CalculateMathFunctionHandler();

            var exception = Assert.ThrowsException<ArgumentException>(
                () => handler.Handle(request, CancellationToken.None).Result);

            Assert.AreEqual(message, exception.Message, true);
        }
    }
}
