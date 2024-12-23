using Domain.Shared.Static;
using Domain.Shared.Utils.TypesResults;

namespace Test.MemberData;

public class HallData
{
    public static IEnumerable<object[]> InvalidNameData()
    {
        yield return new object[] { "", new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.EMPTY_NAME, DomainErrors.Validation.MINIMUM_LENGHT } };
        yield return new object[] { null, new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.EMPTY_NAME, DomainErrors.Validation.NULL_NAME } };
        yield return new object[] { "S", new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.MINIMUM_LENGHT } };
        yield return new object[] { "ffffffffffffffffffffffffffffffffffffffffffffffffff",new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.MAXIMUM_LENGHT } };
        yield return new object[] { "&Invalid@Name#", new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.SPECIFIC_CHARACTERS } };
    }
        
}