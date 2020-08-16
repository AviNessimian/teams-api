namespace InternetTeams.Infrastructure.Services
{
    internal partial class DomainValueRepositoryCache
    {
        internal class CacheKeys
        {
            private readonly static string keyPrefix = $"{nameof(DomainValueRepositoryCache)}_";

            public readonly static string DomainValueCollectionsNames = $"{keyPrefix}_DomainValueCollectionsNames";
            public readonly static string CollactionNameCount = $"{keyPrefix}_CollactionNameCount";
            public readonly static string CollactionTimepointAverage = $"{keyPrefix}_TimepointAverage";
        }

    }
}
