using Desafio.Application.Queries.Requests;
using MediatR;

namespace Desafio.Application.Handlers
{
    public class GetFullNameNumberQueryHandler : IRequestHandler<GetFullNameNumberRequest, GetFullNameNumberResponse>
    {
        private readonly string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
        private readonly string[] others = { "dez", "onze", "doze", "treze", "catorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        private readonly string[] dezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        private readonly string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

        public Task<GetFullNameNumberResponse> Handle(GetFullNameNumberRequest request, CancellationToken cancellationToken)
        {
            var result = new GetFullNameNumberResponse
            {
                FullNameNumber = GetFullName(request.Number)
            };

            return Task.FromResult(result);
        }

        private string GetFullName(int number)
        {
            if (number == 0)
            {
                return "zero";
            }
            else if (number < 0)
            {
                return "menos " + GetFullName(Math.Abs(number));
            }

            string extensive = "";

            if (number >= 1000000)
            {
                var result = number / 1000000;

                extensive += $"{GetFullName(result)} {GetNameMillion(result)}";
                if (number % 1000000 != 0)
                {
                    extensive += " e " + GetFullName(number % 1000000);
                }
            }
            else if (number >= 1000)
            {
                extensive += GetFullName(number / 1000) + " mil";
                if (number % 1000 != 0)
                {
                    extensive += " e " + GetFullName(number % 1000);
                }
            }
            else if (number >= 100)
            {
                extensive += centenas[number / 100];
                if (number % 100 != 0)
                {
                    extensive += " e " + GetFullName(number % 100);
                }
            }
            else if (number >= 20)
            {
                extensive += dezenas[number / 10];

                if (number % 10 != 0)
                {
                    extensive += " e " + GetFullName(number % 10);
                }
            }
            else if (number >= 10)
            {
                extensive += others[number - 10];
            }
            else
            {
                extensive += unidades[number];
            }

            return extensive;
        }

        private static string GetNameMillion(int number)
        {
            return number switch
            {
                1 or -1 => "milhão",
                _ => "milhões"
            };
        }
    }
}
