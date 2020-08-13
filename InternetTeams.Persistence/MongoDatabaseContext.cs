using InternetTeams.Application.Exceptions;
using MongoDB.Bson;
using MongoDB.Driver;
using System;

namespace InternetTeams.Persistence
{
    /// <summary>
    /// Note that as the documentation states whenever you call MongoServer
    /// Create with the same connection string you get the SAME instance of MongoServer back,
    /// so it is not strictly necessary for you to create a singleton reference in your code.
    /// </summary>
    public sealed class MongoDatabaseContext
    {
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDatabaseContext(IDatabaseSettings settings)
        {
            Settings = settings;

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
                ServerSelectionTimeout = TimeSpan.FromSeconds(20),
                //SslSettings = new SslSettings()
                //{
                //    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12
                // }
            };

            _client = new MongoClient(mongoClientSettings);
            _database = _client.GetDatabase(settings.DatabaseName);
        }


        public IMongoDatabase DataBase
        {
            get
            {
                if (IsConnected())
                {
                    return _database;
                }
                else
                {
                    throw new PersistenceException($"the Database {Settings.DatabaseName} is not connected");
                }
            }
        }

        public IDatabaseSettings Settings { get; }

        private bool IsConnected()
        {
            var command = new BsonDocument { { "ping", 1 } };
            try
            {
                var bsonDocument = _database.RunCommand<BsonDocument>(command);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
