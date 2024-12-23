using Domain.Shared.Enums;

namespace Domain.Shared.Utils.TypesResults.SuccessResults;

public class OperationSuccess : BaseSuccess
{
    public string Operation { get; }
    
    public OperationSuccess(string message, SuccessTypes successTypes, string operation) 
        : base(message, successTypes)
    {
        Operation = operation;
    }

    
}