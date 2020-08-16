using InternetTeams.Domain.Entities;
using System.Collections.Generic;

namespace InternetTeams.Application.Models
{
    public class GetDomainValuesByNameResponse
    {
        public GetDomainValuesByNameResponse(long collactionCount, List<DomainValue> domainValues)
        {
            this.CollactionCount = collactionCount;
            this.DomainValues = domainValues;
        }
        public long CollactionCount { get; set; }
        public List<DomainValue> DomainValues { get; set; }
    }
}
