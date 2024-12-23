using Domain.Shared.Enums;

namespace Domain.Shared.Utils.TypesResults;

public class BaseError 
{
    public string Message { get; }
    public ErrorTypes ErrorType { get; }

    public BaseError(string message, ErrorTypes errorType)
    {
        Message = message;
        ErrorType = errorType;
    }
}