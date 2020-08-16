using FluentValidation;
using InternetTeams.Domain.Bases;
using InternetTeams.Domain.Exceptions;

namespace InternetTeams.Domain.Contracts
{
    public class PagingInput : AbstractInput
    {
        public int PageSize { get; set; }
        public int Page { get; set; }

        public override void Validate()
        {
            var validationResult = new AbstractPagingInputValidator().Validate(this);
            if (!validationResult.IsValid)
            {
                throw new DomainValidationException(validationResult.Errors);
            }
            base.Validate();
        }
    }

    public class AbstractPagingInputValidator : AbstractValidator<PagingInput>
    {
        public AbstractPagingInputValidator()
        {
            RuleFor(x => x.Page).NotEmpty();
            RuleFor(x => x.PageSize).NotEmpty();
        }
    }

}
