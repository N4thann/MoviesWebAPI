using Microsoft.AspNetCore.Diagnostics;
using MoviesAPI.Application.DTOs.Response;
using System.Net;

namespace MoviesAPI.Extensions
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //Esse método especifíca o que fazer quando ocorrer uma Exceção não tratada
            //Cria um contexto de reposta
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";//Tipo de conteúdo no formato Json

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetailsRespondeDto()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Trace = contextFeature.Error.StackTrace,
                        }.ToString());
                    }
                });
            });
        }
    }
}
