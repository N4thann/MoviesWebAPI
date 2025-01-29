using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MoviesAPI.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger) => _logger = logger;

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma exceção não tratada: Status Code 500");

            context.Result = new ObjectResult("Ocorreu um problema ao tratar a sua solicitação: Status Code 500")
            {
                StatusCode = StatusCodes.Status500InternalServerError,
            };
        }
    }
}
/*Esse filtro aplica um tratamento global em todas as exceções não tratadas relacionadas ao status code 500.
 * Assim estamos aplicando o príncipio do DRY, podendo retirar os try catch também dos métodos, visto que,
 * ao receber uma exceção já teremos tratamento por aqui.
 */
