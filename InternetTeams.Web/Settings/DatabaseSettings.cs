using InternetTeams.Persistence;

namespace InternetTeams.Web.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionNameBase { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string AuthMechanism { get; set; }
    }
}
