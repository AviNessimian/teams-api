using InternetTeams.Domain.Bases;
using InternetTeams.Domain.Entities;
using InternetTeams.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Domain.Contracts
{
    public interface IDomainValueRepository
    {
        Task<IEnumerable<DomainValue>> Get(string collactionName,
            AbstractPagingRequest pagingRequest,
            Expression<Func<DomainValue, bool>> filter = null,
            CancellationToken cancellationToken = default);

        Task<long> Count(string collactionName, CancellationToken cancellationToken = default);
        Task<IEnumerable<string>> GetDomainValueCollectionsNames(CancellationToken cancellationToken = default);
        Task<IEnumerable<TimepointAverage>> GetTimepointAverage(string collactionName, CancellationToken cancellationToken = default);
    }
}
