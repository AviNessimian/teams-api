using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;


namespace InternetTeams.Persistence.DomainData
{
    public class DbClient : MongoClient
    {
        private readonly IMongoClient _client;

        public DbClient(IConfigurationSection configurationSection)
        {

            var settings = configurationSection.Get<DbSettings>();

            var credentials = MongoCredential.CreateCredential(
                databaseName: settings.DatabaseName,
                username: settings.User,
                password: settings.Password);

            var server = new MongoServerAddress(host: settings.Host, port: settings.Port);

            var mongoClientSettings = new MongoClientSettings
            {
                Credential = credentials,
                Server = server,
                ConnectionMode = ConnectionMode.Standalone,
                ServerSelectionTimeout = TimeSpan.FromSeconds(settings.ServerSelectionTimeoutFromSeconds),
            };

            DatabaseName = settings.DatabaseName;
            _client = new MongoClient(mongoClientSettings);

        }

        public string DatabaseName { get; }
    }


}
