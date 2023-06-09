﻿using Desafio.Application.Requests;
using Desafio.Application.Responses;
using MediatR;
using System;
using System.Linq.Expressions;
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
        private static double GetExpressionValue(string expression)
        {
            bool expressionValid = ValidateExpression(expression);

            if (!expressionValid)
                throw new ArgumentException("Expressão matemática inválida: " + expression);

            while (expression.Contains("*") || expression.Contains("/"))
            {
                expression = CalculatePriorityExpression(expression);
            }
            
            double result = CalculateExpression(expression);

            return result;
        }

        private static bool ValidateExpression(string expression)
        {
            string pattern = @"^[^\d\s].*|.*[\+\-\*\/]$";

            bool invalid = Regex.IsMatch(expression, pattern);

            return !invalid;
        }

        private static string CalculatePriorityExpression(string expression)
        {
            string[] elements = Split(expression).ToArray();            

            int index = elements.Select((num, index) => new { num, index })
                              .Where(x => x.num.Equals("*") || x.num.Equals("/"))
                              .Select(x => x.index).First();

            if (index > 0)
            {
                double result = 0;

                var num1 = double.Parse(elements[index - 1]);
                var num2 = double.Parse(elements[index + 1]);

                switch (elements[index])
                {
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        if (num2 == 0)
                            throw new ArgumentException("Denominador não pode ser '0'");
                        result = num1 / num2;
                        break;
                    default:
                        throw new ArgumentException("Operador inválido: " + elements[index]);
                }

                elements[index - 1] = null;
                elements[index + 1] = null;
                elements[index] = result.ToString();
            }

            return string.Join("", elements);
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
                string operatorr = elements[i];
                double numero = double.Parse(elements[i + 1]);

                switch (operatorr)
                {
                    case "+":
                        result += numero;
                        break;
                    case "-":
                        result -= numero;
                        break;
                    default:
                        throw new ArgumentException("Operador inválido: " + operatorr);
                }
            }

            return result;
        }
        #endregion
    }
}
