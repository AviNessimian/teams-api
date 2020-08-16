using FluentValidation;
using InternetTeams.Application.Exceptions;
using InternetTeams.Domain.Bases;

namespace InternetTeams.Application.Models
{
    public class GetAllDomainValuesRequest : AbstractPagingRequest
    {
        public override void Validate()
        {
            var validationResult = new GetAllDomainValuesRequestValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult.Errors);
            }
        }
    }

    public class GetAllDomainValuesRequestValidator : AbstractValidator<GetAllDomainValuesRequest>
    {
        public GetAllDomainValuesRequestValidator()
        {
            RuleFor(x => x.Page).NotEmpty();
            RuleFor(x => x.PageSize).NotEmpty();
        }
    }
}
