using InternetTeams.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using System.Net;

namespace InternetTeams.Web.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = new FileExtensionContentTypeProvider().Mappings[".json"];

            var appValidationEx = context.Exception as AppValidationException;
            if (appValidationEx != null)
            {
                foreach (var error in appValidationEx.Failures)
                {
                    context.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                var response = JsonConvert.SerializeObject(new
                {
                    Failures = appValidationEx.Failures
                });
                context.Result = new JsonResult(response);
                return;
            }

            var notFoundEx = context.Exception as NotFoundException;
            if (notFoundEx != null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                var response = JsonConvert.SerializeObject(new
                {
                    Message = notFoundEx.Message
                });
                context.Result = new JsonResult(response);
                return;
            }

            var persistenceEx = context.Exception as PersistenceException;
            if (persistenceEx != null)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                var response = JsonConvert.SerializeObject(new
                {
                    Message = persistenceEx.Message
                });
                context.Result = new JsonResult(response);
                return;
            }


            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(new
            {
                ErrorMsg = HttpStatusCode.InternalServerError.ToString()
            });
            return;
        }
    }
}
