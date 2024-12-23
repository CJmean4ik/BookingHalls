using Domain.Shared.Enums;

namespace Domain.Shared.Utils.TypesResults.ErrorsResults;

public class OperationError : BaseError
{
    public string Operation { get; }

    public OperationError(string message, ErrorTypes errorType,string operation)
        : base(message, errorType)
    {
        Operation = operation;
    }
}