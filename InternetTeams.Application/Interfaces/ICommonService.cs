using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface ICommonService
    {
        Task<List<string>> GetDomainNames(CancellationToken cancellationToken = default);

        Task<string> ValidateCollectionsName(string collactionName, CancellationToken cancellationToken = default);
    }
}