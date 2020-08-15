using InternetTeams.Application.Models;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface IGetDomainValuesByNameInteractor
    {
        Task<GetDomainValuesByNameResponse> Handle(GetDomainValuesByNameRequest input, CancellationToken cancellationToken);
    }
}