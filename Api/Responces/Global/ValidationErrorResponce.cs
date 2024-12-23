using Domain.Shared.Utils.TypesResults.ErrorsResults;

namespace Api.Responces.Global;

public class ValidationErrorResponce : BaseResponce
{
    public List<ValidationError> ErrorModels { get; set; } = new List<ValidationError>();
}