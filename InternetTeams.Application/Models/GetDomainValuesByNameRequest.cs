using FluentValidation;
using InternetTeams.Domain.Bases;
using InternetTeams.Domain.Exceptions;

namespace InternetTeams.Application.Models
{
    public class GetDomainValuesByNameRequest : AbstractPagingRequest
    {
        public string CollactionName { get; set; }

        public override void Validate()
        {
            var validationResult = new GetDomainValuesByNameRequestValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult.Errors);
            }
        }
    }

    public class GetDomainValuesByNameRequestValidator : AbstractValidator<GetDomainValuesByNameRequest>
    {
        public GetDomainValuesByNameRequestValidator()
        {
            RuleFor(x => x.Page).NotEmpty();
            RuleFor(x => x.PageSize).NotEmpty();
            RuleFor(x => x.CollactionName).NotNull().NotEmpty();
        }
    }
}
