namespace InternetTeams.Persistence.DomainData
{
    internal class DomainDataSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string DatabaseName { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int ServerSelectionTimeoutFromSeconds { get; set; }
    }
}
