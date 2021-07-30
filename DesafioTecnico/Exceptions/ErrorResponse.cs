using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace WebAPI.Exceptions
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public string[] Detalhes { get; set; }
        public ErrorResponse InnerError { get; set; }

        public static ErrorResponse From(System.Exception e)
        {
            if (e is null) return null;

            return new ErrorResponse
            {
                Codigo = e.HResult,
                Mensagem = e.Message,
                InnerError = ErrorResponse.From(e.InnerException)
            };
        }

        public static ErrorResponse FromModelStateError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors);

            return new ErrorResponse
            {
                Codigo = 100,
                Mensagem = "Houve erro(s) na validação da requisição",
                Detalhes = errors.Select(e => e.ErrorMessage).ToArray(),
            };
        }
    }
}