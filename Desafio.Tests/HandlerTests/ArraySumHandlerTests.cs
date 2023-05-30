using Desafio.Application.Handlers;
using Desafio.Application.Requests;

namespace Desafio.Tests.HandlerTests
{
    [TestClass]
    public class ArraySumHandlerTests
    {
        [TestMethod]
        public void Dada_uma_requisicao_valida_deve_somar_todos_os_valores_do_array_com_sucesso()
        {
            ArraySumRequest request = new ArraySumRequest
            {
                Numbers = new int[] { 1, 2, 3, 4, 5 }
            };

            int expectedResult = 15;

            var handler = new ArraySumHandler();

            var result = handler.Handle(request, CancellationToken.None).Result;

            Assert.AreEqual(result.Sum, expectedResult);
        }        
    }
}
