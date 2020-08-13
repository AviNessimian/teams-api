namespace InternetTeams.Application.Models
{
    public abstract class GetBaseRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
    }
}
