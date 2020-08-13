using InternetTeams.Application.Exceptions;
using InternetTeams.Application.Interfaces;
using FluentValidation;

namespace InternetTeams.Application.Models
{
    public class GetDomainValuesByNameRequest : GetBaseRequest, IRequestModel
    {
        public string CollactionName { get; set; }

        public void Validate()
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
