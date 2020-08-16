using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace InternetTeams.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException() : base("One or more validation failures have occurred.")
        {
            Failures = new List<ValidationFailure>();
        }

        public DomainValidationException(IList<ValidationFailure> failures) : this()
        {
            Failures = failures;
        }

        public DomainValidationException(ValidationFailure failure) : this()
        {
            Failures.Add(failure);
        }

        public IList<ValidationFailure> Failures { get; set; }
    }
}
