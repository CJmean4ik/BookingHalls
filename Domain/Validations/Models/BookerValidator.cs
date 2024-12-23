using System.Text.RegularExpressions;
using Domain.Models;
using Domain.Shared.Constants;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations.Models;

public class BookerValidator : AbstractValidator<Booker>
{
    public BookerValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator());
        ValidateName();
        ValidateSurname();
        ValidateEmail();
    }
    
    private void ValidateName()
    {
        RuleFor(r => r.Name)
            .NotEmpty().WithError(DomainErrors.Validation.EMPTY_NAME)
            .NotNull().WithError(DomainErrors.Validation.NULL_NAME)
            .MinimumLength(Validation.MIN_USERNAME_LENGHT).WithError(DomainErrors.Validation.MINIMUM_LENGHT)
            .MaximumLength(Validation.MAX_USERNAME_LENGHT).WithError(DomainErrors.Validation.MAXIMUM_LENGHT)
            .Must(name => !Regex.IsMatch(name, Validation.REGULAR_SPECIFIC_CHARACTERS_PATTERN))
            .WithError(DomainErrors.Validation.SPECIFIC_CHARACTERS);
    }
    private void ValidateSurname()
    {
        RuleFor(r => r.Surname)
            .NotEmpty().WithError(DomainErrors.Validation.EMPTY_SURNAME)
            .NotNull().WithError(DomainErrors.Validation.NULL_SURNAME)
            .MinimumLength(Validation.MIN_SURNAME_LENGHT).WithError(DomainErrors.Validation.MINIMUM_LENGHT)
            .MaximumLength(Validation.MAX_SURNAME_LENGHT).WithError(DomainErrors.Validation.MAXIMUM_LENGHT)
            .Must(name => !Regex.IsMatch(name, Validation.REGULAR_SPECIFIC_CHARACTERS_PATTERN))
            .WithError(DomainErrors.Validation.SPECIFIC_CHARACTERS);
    }
    private void ValidateEmail()
    {
        RuleFor(r => r.Surname)
            .NotEmpty().WithError(DomainErrors.Validation.EMPTY_SURNAME)
            .NotNull().WithError(DomainErrors.Validation.NULL_SURNAME)
            .Must(name => Regex.IsMatch(name, Validation.REGULAR_EMAIL_PATTERN))
            .WithError(DomainErrors.Validation.INCORRECT_EMAIL);
    }
}