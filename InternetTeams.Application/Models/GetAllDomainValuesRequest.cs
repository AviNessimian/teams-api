using FluentValidation;
using InternetTeams.Application.Exceptions;
using InternetTeams.Application.Contracts;

namespace InternetTeams.Application.Models
{
    public class GetAllDomainValuesRequest : PagingInput
    {
        public override void Validate()
        {
            if (!IsValid)
            {
                var validationResult = new GetAllDomainValuesRequestValidator().Validate(this);
                if (!validationResult.IsValid)
                {
                    throw new AppValidationException(validationResult.Errors);
                }
                base.Validate();
            }
        }
    }

    public class GetAllDomainValuesRequestValidator : AbstractValidator<GetAllDomainValuesRequest>
    {
        public GetAllDomainValuesRequestValidator()
        {
        }
    }
}
