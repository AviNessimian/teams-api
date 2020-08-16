namespace InternetTeams.Domain.Bases
{
    public abstract class AbstractPagingRequest : AbstractRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
