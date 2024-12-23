using Domain.Shared.Utils.TypesResults.ErrorsResults;
using Domain.Shared.Utils.TypesResults;

namespace Domain.Shared.Utils;

public class TResult<TValue> : Result
{
    public TValue? Value { get;}

    public TResult(TValue? value, BaseSuccess? success = null, BaseError? error = null) 
        : base(success, error)
    {
        Value = value;
    }

    public override TResult<TValue> AddErrorReasons(params BaseError[] errorBase)
    {
        _errorReasons.AddRange(errorBase);
        return this;
    }
}