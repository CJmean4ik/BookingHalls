using System.Text.RegularExpressions;
using Domain.Models;
using Domain.Shared.Constants;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations.Models;

public class ServicesValidator : AbstractValidator<Service>
{
    public ServicesValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator());
        ValidatePrice();
        ValidateName();
    }

    private void ValidatePrice()
    {
        RuleFor(r => r.Price)
            .NotEqual(0).WithError(DomainErrors.Validation.ZERO_PRICE);
    }
    private void ValidateName()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(DomainErrors.Validation.EMPTY_NAME)
            .NotNull().WithError(DomainErrors.Validation.NULL_NAME)
            .MinimumLength(Validation.MIN_SERVICE_NAME_LENGHT).WithError(DomainErrors.Validation.MINIMUM_LENGHT)
            .MaximumLength(Validation.MAX_SERVICE_NAME_LENGHT).WithError(DomainErrors.Validation.MAXIMUM_LENGHT)
            .Must(name => !Regex.IsMatch(name, Validation.REGULAR_SPECIFIC_CHARACTERS_PATTERN))
            .WithError(DomainErrors.Validation.SPECIFIC_CHARACTERS);
    }
}