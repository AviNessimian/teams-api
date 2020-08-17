using FluentValidation;
using InternetTeams.Application.Exceptions;
using InternetTeams.Application.Contracts;

namespace InternetTeams.Application.Models
{
    public class GetDomainValuesByNameRequest : PagingInput
    {
        public string CollactionName { get; set; }

        public override void Validate()
        {
            if (!IsValid)
            {
                var validationResult = new GetDomainValuesByNameRequestValidator().Validate(this);
                if (!validationResult.IsValid)
                {
                    throw new AppValidationException(validationResult.Errors);
                }
                base.Validate();
            }
        }
    }

    public class GetDomainValuesByNameRequestValidator : AbstractValidator<GetDomainValuesByNameRequest>
    {
        public GetDomainValuesByNameRequestValidator()
        {
            RuleFor(x => x.CollactionName).NotNull().NotEmpty();
        }
    }
}
