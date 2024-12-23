using Domain.Shared.Utils.TypesResults;
using FluentValidation;

namespace Domain.Shared.Extensions;

public static class FluentValidatorExtension
{
    public static IRuleBuilderOptions<T, TProperty> WithError<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> ruleBuilderOptions,
        BaseError baseError)
    {
        ruleBuilderOptions
            .WithMessage(baseError.Message)
            .WithErrorCode(baseError.ErrorType.ToString());
        return ruleBuilderOptions;
    }
}