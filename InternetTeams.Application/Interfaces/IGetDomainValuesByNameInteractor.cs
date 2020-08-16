using InternetTeams.Application.Models;
using InternetTeams.Domain.Bases;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface IGetDomainValuesByNameInteractor
    {
        Task<GetDomainValuesByNameResponse> Handle(Input<GetDomainValuesByNameRequest> input, CancellationToken cancellationToken);
    }
}