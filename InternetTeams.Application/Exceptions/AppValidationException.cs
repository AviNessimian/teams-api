using FluentValidation.Results;
using InternetTeams.Domain.Exceptions;
using System.Collections.Generic;

namespace InternetTeams.Application.Exceptions
{
    public class AppValidationException : DomainValidationException
    {
        public AppValidationException() : base() { }

        public AppValidationException(IList<ValidationFailure> failures) : base(failures) { }

        public AppValidationException(ValidationFailure failure) : base(failure) { }
    }
}
