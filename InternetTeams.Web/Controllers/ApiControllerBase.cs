using InternetTeams.Web.Filters;
using Microsoft.AspNetCore.Mvc;

namespace InternetTeams.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ValidationActionFilter))]
    [TypeFilter(typeof(ApiExceptionFilter))]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
