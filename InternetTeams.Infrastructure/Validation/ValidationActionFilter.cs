using InternetTeams.Domain.Bases;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace InternetTeams.Infrastructure.Validation
{
    internal class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // our code before action executes
            foreach (var argument in context.ActionArguments.Values.Where(v => v is AbstractRequest))
            {
                var request = argument as AbstractRequest;
                request.Validate();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // our code after action executes
        }
    }
}
