using System.Text.RegularExpressions;
using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations;

public class PassswordValidator : AbstractValidator<string>
{
    public PassswordValidator()
    {
        RuleFor(r => r)
            .NotNull().WithMessage("The password must not be null").WithErrorCode(ErrorTypes.ValueNull.ToString())
            .NotEmpty().WithMessage("The password must not be empty").WithErrorCode(ErrorTypes.EmptyValue.ToString())
            .MinimumLength(Validation.MIN_PASSWORD_LENGHT).WithError(DomainErrors.Validation.MINIMUM_LENGHT)
            .MaximumLength(Validation.MAX_PASSWORD_LENGHT).WithError(DomainErrors.Validation.MAXIMUM_LENGHT)
            .Must(password => Regex.IsMatch(password, Validation.REGULAR_PASSWORD_UPPERCASE_PATTERN)   && 
                              Regex.IsMatch(password, Validation.REGULAR_PASSWORD_LOWERCASE_PATTERN)        &&
                              Regex.IsMatch(password, Validation.REGULAR_PASSWORD_SPECIAL_HARACTER_PATTERN) &&
                              Regex.IsMatch(password, Validation.REGULAR_PASSWORD_DIGIT_PATTERN))
            .WithError(DomainErrors.Validation.INVALID_PASSWORD);
        
    }
}