using InternetTeams.Domain.Bases;
using System.Collections.Generic;

namespace InternetTeams.Domain.ValueObjects
{
    public class TimepointAverage : ValueObject
    {
        public double Timepoint { get; set; }
        public double AverageValue { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Timepoint;
            yield return AverageValue;
        }
    }
}
