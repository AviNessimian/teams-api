using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;


namespace InternetTeams.Persistence.DomainData
{
    internal class DomainDataClient : MongoClient
    {
        internal DomainDataClient(IConfigurationSection configurationSection)
            : base(GeSettings(configurationSection.Get<DomainDataSettings>())) { }


        internal static MongoClientSettings GeSettings(DomainDataSettings settings)
        {
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

            return mongoClientSettings;
        }

    }
}
