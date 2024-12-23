using Domain.Shared.Enums;

namespace Domain.Shared.Utils.TypesResults;

public class BaseSuccess
{
    public string Message { get; }
    public SuccessTypes SuccessTypes { get; }

    public BaseSuccess(string message, SuccessTypes successTypes)
    {
        Message = message;
        SuccessTypes = successTypes;
    }
}