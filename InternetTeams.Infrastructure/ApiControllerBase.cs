using InternetTeams.Infrastructure.ExceptionHandling;
using InternetTeams.Infrastructure.Validation;
using Microsoft.AspNetCore.Mvc;

namespace InternetTeams.Infrastructure
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationActionFilter))]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
