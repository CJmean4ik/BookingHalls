using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations;

public class IdValidator : AbstractValidator<Guid?>
{
    public IdValidator()
    {
        RuleFor(r => r)
            .NotEqual(Guid.Empty).WithError(DomainErrors.Validation.EMPTY_ID);
    }
}