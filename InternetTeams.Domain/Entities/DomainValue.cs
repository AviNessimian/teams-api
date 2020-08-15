using InternetTeams.Domain.Bases;

namespace InternetTeams.Domain.Entities
{
    public class DomainValue : Entity
    {
        public string SubjectId { get; set; }
        public double Timepoint { get; set; }
        public double NumericValue { get; set; }
    }
}
