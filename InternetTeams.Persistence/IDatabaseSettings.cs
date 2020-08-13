namespace InternetTeams.Persistence
{
    public interface IDatabaseSettings
    {
        string Host { get; set; }
        int Port { get; set; }
        string DatabaseName { get; set; }
        string CollectionNameBase { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string AuthMechanism { get; set; }
    }
}
