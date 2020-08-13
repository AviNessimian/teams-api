using InternetTeams.Application.Interfaces;
using InternetTeams.Domain.Entities;
using InternetTeams.Domain.ValueObjects;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InternetTeams.Persistence
{
    public class DomainValueRepository : IDomainValueRepository
    {
        private readonly MongoDatabaseContext _dbContext;

        public DomainValueRepository(MongoDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DomainValue>> Get(
            string collactionName,
            int pageSize,
            int page,
            Expression<Func<DomainValue, bool>> filter = null)
        {
            var collaction = _dbContext.DataBase.GetCollection<DomainValue>(collactionName);

            if (filter == null)
            {
                filter = (x) => x.SubjectId != null;
            }

            var domainValues = await collaction
                .Find(filter)
                .Skip((page - 1) * pageSize)
                .Limit(pageSize)
                .ToListAsync();

            return domainValues;

        }

        public async Task<IEnumerable<string>> GetDomainValueCollectionsNames()
        {
            var collections = new List<string>();

            foreach (var collection in await (await _dbContext.DataBase.ListCollectionsAsync()).ToListAsync())
            {
                var name = collection["name"].AsString;

                if (name.ToLower().StartsWith(_dbContext.Settings.CollectionNameBase.ToLower()))
                {
                    collections.Add(name);
                }
            }

            return collections;
        }


        public async Task<long> Count(string collactionName)
        {
            var collaction = _dbContext.DataBase.GetCollection<DomainValue>(collactionName);
            return await collaction.EstimatedDocumentCountAsync();
        }

        public async Task<IEnumerable<TimepointAverage>> GetTimepointAverage(string collactionName)
        {
            var timepointAverageList = new List<TimepointAverage>();

            var collaction = _dbContext.DataBase.GetCollection<DomainValue>(collactionName);

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

            var cursor = await collaction.AggregateAsync<BsonDocument>(pipeline);

            foreach (var item in await cursor.ToListAsync())
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
