using InternetTeams.Application.Bases;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace InternetTeams.Web.Filters
{
    internal class ValidationActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            foreach (var argument in context.ActionArguments.Values.Where(v => v is AbstractInput))
            {
                var request = argument as AbstractInput;
                request.Validate();
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
