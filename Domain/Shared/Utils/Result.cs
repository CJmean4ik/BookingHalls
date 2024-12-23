using Domain.Shared.Utils.TypesResults.ErrorsResults;
using Domain.Shared.Utils.TypesResults;

namespace Domain.Shared.Utils;

public class Result
{
    private protected readonly List<BaseError> _errorReasons = new List<BaseError>();
    public bool IsFailure => _errorReasons.Any() || Error is not null;
    public bool IsSuccess => Success is not null;
    public IReadOnlyCollection<BaseError> ErrorReasons => _errorReasons;
    public BaseSuccess? Success { get;}
    public BaseError? Error { get; }

    protected Result(BaseSuccess? success = null, BaseError? error = null)
    {
        if (success is not null && error is not null)
        {
            throw new InvalidOperationException("Cannot create Result with success and error");
        }
        Success = success;
        Error = error;
    }

    public virtual Result AddErrorReasons(params BaseError[] errorBase)
    {
        _errorReasons.AddRange(errorBase);
        return this;
    }
    public static Result CreateSuccess(BaseSuccess baseSuccess)
    {
        var result = new Result(success: baseSuccess);
        return result;
    }
    
    public static Result CreateFailure(BaseError baseError)
    {
        var result = new Result(error: baseError);
        return result;
    }
    
    public static TResult<TValue> CreateSuccess<TValue>(TValue value,BaseSuccess baseSuccess)
    {
        var result = new TResult<TValue>(value,success: baseSuccess);
        return result;
    }
    
    public static  TResult<TValue> CreateFailure<TValue>(BaseError baseError)
    {
        var result = new TResult<TValue>(default,error: baseError);
        return result;
    }

    public TResult<TValue> CopyToTResult<TValue>(Result result, TValue? value = default)
    {
        if (result.IsFailure)
        {
            var tResult = CreateFailure<TValue>(result.Error!);
            if (result.ErrorReasons.Any())
                tResult.AddErrorReasons(result.ErrorReasons.ToArray());

            return tResult;
        }
        
        return CreateSuccess<TValue>(value!, result.Success!);
    }
}