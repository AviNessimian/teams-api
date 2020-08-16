using InternetTeams.Persistence.Exceptions;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InternetTeams.Persistence.DomainData
{
    internal class DomainDataContext
    {
        internal DomainDataContext(DomainDataClient client)
        {
            var dbName = client.Settings.Credential?.Identity?.Source
                ??
                throw new ArgumentNullException("Source cant be null!");

            Database = client.GetDatabase(dbName);

            if (!Ping())
            {
                throw new PersistenceException($"the Database {dbName} is not connected");
            }
        }

        internal IMongoDatabase Database { get; }

        internal bool Ping()
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
