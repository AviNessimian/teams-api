using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;

namespace InternetTeams.Infrastructure.ExceptionHandling
{
    public class GlobalExceptionHandler
    {
        public static RequestDelegate Run(ILoggerFactory loggerFactory)
        =>
            async context =>
                    {

                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";

                        await context.Response.WriteAsync("Fatal ERROR!");

                        var exceptionFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                        Exception exceptionThatOccurred = exceptionFeature.Error;

                        var looger = loggerFactory.CreateLogger<GlobalExceptionHandler>();

                        looger.LogCritical(exceptionThatOccurred, exceptionThatOccurred.Message);
                    };
    }
}
