using InternetTeams.Domain.Entities;
using InternetTeams.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InternetTeams.Application.Interfaces
{
    public interface IDomainValueRepository
    {
        Task<IEnumerable<DomainValue>> Get(string collactionName,
            int pageSize,
            int page,
            Expression<Func<DomainValue, bool>> filter = null);

        Task<long> Count(string collactionName);
        Task<IEnumerable<string>> GetDomainValueCollectionsNames();

        Task<IEnumerable<TimepointAverage>> GetTimepointAverage(string collactionName);
    }
}
