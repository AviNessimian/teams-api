using InternetTeams.Application.Bases;
using InternetTeams.Application.Contracts;
using InternetTeams.Domain.Entities;
using InternetTeams.Domain.ValueObjects;
using LazyCache;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Infrastructure.Services
{
    internal partial class DomainValueRepositoryCache : IDomainValueRepository
    {
        private readonly IDomainValueRepository _domainValueRepository;
        private readonly IAppCache _cache;
        private readonly ILogger _logger;

        public DomainValueRepositoryCache(
            IDomainValueRepository domainValueRepository,
            IAppCache appCache,
            ILogger<DomainValueRepositoryCache> logger)
        {
            _domainValueRepository = domainValueRepository;
            _logger = logger;
            _cache = appCache;
        }

        public async Task<IEnumerable<DomainValue>> Get(
            string collactionName,
            Input<PagingInput> pagingInput,
            Expression<Func<DomainValue, bool>> filter = null,
            CancellationToken cancellationToken = default)
            => await _domainValueRepository.Get(collactionName, pagingInput, filter, cancellationToken);

        public async Task<IEnumerable<string>> GetDomainValueCollectionsNames(CancellationToken cancellationToken = default)
        {
            Func<Task<IEnumerable<string>>> showObjectFactory = async () => await _domainValueRepository.GetDomainValueCollectionsNames(cancellationToken);
            var retVal = await _cache.GetOrAddAsync(CacheKeys.DomainValueCollectionsNames, showObjectFactory, DateTimeOffset.Now.AddMinutes(10));
            return retVal;
        }

        public async Task<long> Count(string collactionName, CancellationToken cancellationToken = default)
            => await _domainValueRepository.Count(collactionName, cancellationToken);


        public async Task<IEnumerable<TimepointAverage>> GetTimepointAverage(string collactionName, CancellationToken cancellationToken = default)
            => await _domainValueRepository.GetTimepointAverage(collactionName, cancellationToken);
    }
}
