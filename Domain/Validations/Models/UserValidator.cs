using Domain.Models;
using Domain.Shared.Constants;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations.Models;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator());
        ValidateHashedPassword();
        ValidateSaltPassword();
    }

    private void ValidateHashedPassword()
    {
        RuleFor(r => r.HashedPassword)
            .NotNull().WithError(DomainErrors.Validation.PASSWORD_HASH_IS_NULL)
            .NotEmpty().WithError(DomainErrors.Validation.PASSWORD_HASH_IS_EMPTY)
            .MinimumLength(Validation.MIN_HASHED_PASSWORD_LENGHT)
            .WithError(DomainErrors.Validation.MINIMUM_LENGHT)
            .Must(passwordHash =>
            {
                if (passwordHash is null)
                    return false;
                
                return passwordHash.StartsWith(Validation.EXPECTED_HASHED_PASSWORD_PREFIX);
            })
            .WithError(DomainErrors.Validation.PASSWORD_HASH_INCORRECT_FORMAT)
            .Must((user,password) => password.Contains(user.SaltPassword)).WithError(DomainErrors.Validation.PASSWORD_HASH_NOT_UNIQUE);
    }
    private void ValidateSaltPassword()
    {
        RuleFor(r => r.SaltPassword)
            .NotNull().WithError(DomainErrors.Validation.PASSWORD_SALT_IS_NULL)
            .NotEmpty().WithError(DomainErrors.Validation.PASSWORD_SALT_IS_EMPTY);
    }
}