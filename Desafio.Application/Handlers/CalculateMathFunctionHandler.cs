using Desafio.Application.Requests;
using Desafio.Application.Responses;
using MediatR;
using System.Text.RegularExpressions;

namespace Desafio.Application.Handlers
{
    public class CalculateMathFunctionHandler : IRequestHandler<CalculateMathFunctionRequest, CalculateMathFunctionResponse>
    {
        public Task<CalculateMathFunctionResponse> Handle(CalculateMathFunctionRequest request, CancellationToken cancellationToken)
        {
            CalculateMathFunctionResponse result = new CalculateMathFunctionResponse
            {
                Result = GetExpressionValue(request.Function)
            };

            return Task.FromResult(result);
        }

        #region Métodos auxiliares
        private static double GetExpressionValue(string expressao)
        {
            while (expressao.Contains("*") || expressao.Contains("/"))
            {
                expressao = CalculatePriorityExpression(expressao);
            }
            
            double result = CalculateExpression(expressao);

            return result;
        }

        private static string CalculatePriorityExpression(string expression)
        {
            string[] partes = Split(expression).ToArray();

            double resultado = double.Parse(partes[0]);

            int index = partes.Select((num, index) => new { num, index })
                              .Where(x => x.num.Equals("*") || x.num.Equals("/"))
                              .Select(x => x.index).First();

            if (index > 0)
            {
                double result = 0;

                var num1 = double.Parse(partes[index - 1]);
                var num2 = double.Parse(partes[index + 1]);

                switch (partes[index])
                {
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                            throw new ArgumentException("Denominador não pode ser '0' " + partes[index]);
                        result = num1 / num2;
                        break;
                    default:
                        throw new ArgumentException("Operador inválido: " + partes[index]);
                }

                partes[index - 1] = null;
                partes[index + 1] = null;
                partes[index] = result.ToString();
            }

            return string.Join("", partes);
        }

        private static IEnumerable<string> Split(string expression)
        {
            string pattern = @"([\+\-\*\/])|\s+";
            string[] elements = Regex.Split(expression, pattern).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            return elements;
        }

        private static double CalculateExpression(string expression)
        {
            string[] elements = Split(expression).ToArray();

            double result = double.Parse(elements[0]);

            for (int i = 1; i < elements.Length; i += 2)
            {
                string operador = elements[i];
                double numero = double.Parse(elements[i + 1]);

                switch (operador)
                {
                    case "+":
                        result += numero;
                        break;
                    case "-":
                        result -= numero;
                        break;
                    default:
                        throw new ArgumentException("Operador inválido: " + operador);
                }
            }

            return result;
        }
        #endregion
    }
}
