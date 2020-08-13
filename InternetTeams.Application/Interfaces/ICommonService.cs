using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface ICommonService
    {
        Task<List<string>> GetDomainNames();

        Task<string> ValidateCollectionsName(string collactionName);
    }
}