using FluentValidation;
using InternetTeams.Application.Exceptions;
using InternetTeams.Application.Bases;

namespace InternetTeams.Application.Models
{
    public class CalculateTimepointsAverageRequest : AbstractInput
    {
        public string CollactionName { get; set; }

        public override void Validate()
        {
            if (!IsValid)
            {
                var validationResult = new CalculateTimepointsAverageValidator().Validate(this);
                if (!validationResult.IsValid)
                {
                    throw new AppValidationException(validationResult.Errors);
                }
                base.Validate();
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
