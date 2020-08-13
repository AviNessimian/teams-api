using InternetTeams.Application.Exceptions;
using InternetTeams.Application.Interfaces;
using FluentValidation;

namespace InternetTeams.Application.Models
{
    public class GetAllDomainValuesRequest : GetBaseRequest, IRequestModel
    {
        public void Validate()
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
