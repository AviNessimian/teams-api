using InternetTeams.Application.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace InternetTeams.Web.Filters
{
    public class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes

            foreach (var argument in context.ActionArguments.Values.Where(v => v is IRequestModel))
            {
                IRequestModel request = argument as IRequestModel;
                request.Validate();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
