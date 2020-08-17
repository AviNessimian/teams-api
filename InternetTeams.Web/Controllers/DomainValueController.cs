using InternetTeams.Application.Interfaces;
using InternetTeams.Application.Models;
using InternetTeams.Application.Bases;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Web.Controllers
{
    public class DomainValuesController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken,
            [FromServices] IGetAllDomainValuesInteractor Interactor,
            [FromQuery] GetAllDomainValuesRequest request) => Ok(await Interactor.Handle(Input<GetAllDomainValuesRequest>.Set(request), cancellationToken));


        [HttpGet("ByName")]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken,
            [FromServices] IGetDomainValuesByNameInteractor Interactor,
            [FromQuery] GetDomainValuesByNameRequest request) => Ok(await Interactor.Handle(Input<GetDomainValuesByNameRequest>.Set(request), cancellationToken));


        [HttpGet("DomainNames")]
        public async Task<IActionResult> Get(
              CancellationToken cancellationToken,
              [FromServices] ICommonService commonService) => Ok(await commonService.GetDomainNames(cancellationToken));


        [HttpGet("TimepointsAverage")]
        public async Task<IActionResult> Get(
            CancellationToken cancellationToken,
            [FromServices] ICalculateTimepointsAverageInteractor Interactor,
            [FromQuery] CalculateTimepointsAverageRequest request) => Ok(await Interactor.Handle(Input<CalculateTimepointsAverageRequest>.Set(request), cancellationToken));

    }
}
