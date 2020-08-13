using InternetTeams.Application.Exceptions;
using InternetTeams.Application.Interfaces;
using FluentValidation;

namespace InternetTeams.Application.Models
{
    public class CalculateTimepointsAverageRequest : IRequestModel
    {
        public string CollactionName { get; set; }
        public void Validate()
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
