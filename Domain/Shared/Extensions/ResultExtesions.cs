using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Shared.Utils.TypesResults;
using Domain.Shared.Utils.TypesResults.ErrorsResults;
using FluentValidation.Results;

namespace Domain.Shared.Extensions;

public static class ResultExtensions
{
    public static TResult<T> AddValidationError<T>(
        this TResult<T> result,
        BaseError baseError,
        List<ValidationFailure> failures)
    {
        if (baseError is ValidationError validationError)
        {
            
            validationError.AddValidationDetail(failures.Select(s =>
            {
                var errorType = (ErrorTypes)Enum.Parse(typeof(ErrorTypes), s.ErrorCode);
                var error = new ValidationDetail(s.PropertyName, s.ErrorMessage, errorType);
                return error;
            }).ToList());

            result.AddErrorReasons(validationError);
            return result;
        }

        return result;
    }
    
    public static Result AddException(
        this Result result,
        Exception exception,
        string operationName)
    {
        var operationException = new OperationError(exception.Message,ErrorTypes.GlobalError,operationName);
        result.AddErrorReasons(operationException);
        return result;
    }
}