using InternetTeams.Application.Exceptions;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InternetTeams.Persistence.DomainData
{
    internal class DbContext
    {
        public DbContext(DbClient client)
        {
            var dbName = client.DatabaseName;
            Database = client.GetDatabase(dbName);
            if (!Ping())
            {
                throw new PersistenceException($"the Database {dbName} is not connected");
            }

        }

        public IMongoDatabase Database { get; }

        public bool Ping()
        {
            var command = new BsonDocument { { "ping", 1 } };
            try
            {
                var bsonDocument = Database.RunCommand<BsonDocument>(command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
