using Domain.Shared.Enums;

namespace Domain.Shared.Utils.TypesResults.ErrorsResults;

public class ValidationError : BaseError
{
    private List<ValidationDetail> _validationDetails = new List<ValidationDetail>();
    public IReadOnlyCollection<ValidationDetail> InvalidProperties => _validationDetails;
    public ValidationError(string message, ErrorTypes errorType) 
        : base(message,errorType)
    {
    }

    public ValidationError AddValidationDetail(ValidationDetail validationDetail)
    {
        _validationDetails.Add(validationDetail);
        return this;
    }
    public ValidationError AddValidationDetail(List<ValidationDetail> validationDetails)
    {
        _validationDetails.AddRange(validationDetails);
        return this;
    }
}

public record class ValidationDetail(string Field,string Message,ErrorTypes ErrorTypes);