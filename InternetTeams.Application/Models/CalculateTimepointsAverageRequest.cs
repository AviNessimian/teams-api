using FluentValidation;
using InternetTeams.Application.Exceptions;
using InternetTeams.Domain.Bases;

namespace InternetTeams.Application.Models
{
    public class CalculateTimepointsAverageRequest : AbstractRequest
    {
        public string CollactionName { get; set; }
        public override void Validate()
        {
            var validationResult = new CalculateTimepointsAverageValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new AppValidationException(validationResult.Errors);
            }
        }
    }

    public class CalculateTimepointsAverageValidator : AbstractValidator<CalculateTimepointsAverageRequest>
    {
        public CalculateTimepointsAverageValidator()
        {
            RuleFor(x => x.CollactionName).NotNull().NotEmpty();
        }
    }

}
