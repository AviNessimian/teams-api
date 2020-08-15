using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace InternetTeams.Domain.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException() : base("One or more validation failures have occurred.")
        {
            Failures = new List<ValidationFailure>();
        }

        public AppValidationException(IList<ValidationFailure> failures) : this()
        {
            Failures = failures;
        }

        public AppValidationException(ValidationFailure failure) : this()
        {
            Failures.Add(failure);
        }

        public IList<ValidationFailure> Failures { get; set; }
    }
}
