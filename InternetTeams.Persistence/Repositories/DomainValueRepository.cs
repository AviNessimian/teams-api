using InternetTeams.Domain.Contracts;
using InternetTeams.Domain.Entities;
using InternetTeams.Domain.ValueObjects;
using InternetTeams.Persistence.DomainData;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace InternetTeams.Persistence.Repositories
{
    internal class DomainValueRepository : IDomainValueRepository
    {
        private readonly DomainDataContext _dbContext;
        private readonly IConfiguration _configuration;

        public DomainValueRepository(DomainDataContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<IEnumerable<DomainValue>> Get(
            string collactionName,
            int pageSize,
            int page,
            Expression<Func<DomainValue, bool>> filter = null,
            CancellationToken cancellationToken = default)
        {
            var collaction = _dbContext.Database.GetCollection<DomainValue>(collactionName);

            var domainValues = await collaction
                .Find(filter ?? (_ => true))
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync(cancellationToken);

            return domainValues;
        }

        public async Task<IEnumerable<string>> GetDomainValueCollectionsNames(CancellationToken cancellationToken = default)
        {
            var collectionsNamesList = new List<string>();

            var asyncCursor = await _dbContext.Database.ListCollectionsAsync(null, cancellationToken);
            foreach (var document in await asyncCursor.ToListAsync(cancellationToken))
            {
                var name = document["name"].AsString;

                var collectionNameBase = _configuration.GetValue<string>("CollectionNameBase");

                if (name.ToLower().StartsWith(collectionNameBase.ToLower()))
                {
                    collectionsNamesList.Add(name);
                }
            }

            return collectionsNamesList;
        }


        public async Task<long> Count(string collactionName, CancellationToken cancellationToken = default)
        {
            var collaction = _dbContext.Database.GetCollection<DomainValue>(collactionName);
            return await collaction.EstimatedDocumentCountAsync(null, cancellationToken);
        }


        public async Task<IEnumerable<TimepointAverage>> GetTimepointAverage(string collactionName, CancellationToken cancellationToken = default)
        {
            var timepointAverageList = new List<TimepointAverage>();

            var collaction = _dbContext.Database.GetCollection<DomainValue>(collactionName);

            var pipeline = new BsonDocument[]
            {
                new BsonDocument{
                    {"$group",
                        new BsonDocument{
                            {"_id", $"${nameof(DomainValue.Timepoint)}"},
                            { "average", new BsonDocument{ { "$avg", $"${nameof(DomainValue.NumericValue)}" } } }
                        }
                    }}
            };

            var cursor = await collaction.AggregateAsync<BsonDocument>(pipeline, null, cancellationToken);

            foreach (var item in await cursor.ToListAsync(cancellationToken))
            {
                var newTimepointAverage = new TimepointAverage();
                newTimepointAverage.Timepoint = Convert.ToDouble(item[0]);
                newTimepointAverage.AverageValue = Convert.ToDouble(item[1]);
                timepointAverageList.Add(newTimepointAverage);
            }

            return timepointAverageList;
        }

    }
}
