using InternetTeams.Application.Models;
using InternetTeams.Application.Bases;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface IGetDomainValuesByNameInteractor
    {
        Task<GetDomainValuesByNameResponse> Handle(Input<GetDomainValuesByNameRequest> input, CancellationToken cancellationToken);
    }
}