using Domain.Shared.Utils.TypesResults;

namespace Api.Responces.Global;

public class ErrorResponce : BaseResponce
{
    public List<BaseError> ErrorModels { get; set; } = new List<BaseError>();
}