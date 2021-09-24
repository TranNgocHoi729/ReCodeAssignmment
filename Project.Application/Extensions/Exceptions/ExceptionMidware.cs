using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Project.Core.Messages;
using System.Net;

namespace Project.Application.Extensions.Exceptions
{
    public static class ExceptionMidware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if(exceptionHandlerPathFeature != null)
                    {
                        await context.Response.WriteAsync(CrudMessage.Error);
                    }
                });
            });
        }
    }
}
