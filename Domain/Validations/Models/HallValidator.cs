using System.Text.RegularExpressions;
using Domain.Models;
using Domain.Shared.Constants;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations;

public class HallValidator : AbstractValidator<Hall>
{
    public HallValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator());
        ValidateSeats();
        ValidatePrice();
        ValidateName();
    }

    private void ValidateSeats()
    {
        RuleFor(r => r.Seats)
            .NotEqual(0).WithError(DomainErrors.Validation.ZERO_SEATS);
    }
    private void ValidatePrice()
    {
        RuleFor(r => r.BasePricePerHour)
            .NotEqual(0).WithError(DomainErrors.Validation.ZERO_PRICE);
    }
    private void ValidateName()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(DomainErrors.Validation.EMPTY_NAME)
            .NotNull().WithError(DomainErrors.Validation.NULL_NAME)
            .MinimumLength(Validation.MIN_HALL_NAME_LENGHT).WithError(DomainErrors.Validation.MINIMUM_LENGHT)
            .MaximumLength(Validation.MAX_HALL_NAME_LENGHT).WithError(DomainErrors.Validation.MAXIMUM_LENGHT)
            .Must(name => !Regex.IsMatch(name, Validation.REGULAR_SPECIFIC_CHARACTERS_PATTERN))
            .WithError(DomainErrors.Validation.SPECIFIC_CHARACTERS);
    }
}