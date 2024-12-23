using Domain.Models;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Shared.Utils.TypesResults;
using Test.MemberData;

namespace Test;

public class HallValidatorTest
{
    public static IEnumerable<object[]> InvalidNameData()
    {
        yield return new object[] { "", new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.EMPTY_NAME, DomainErrors.Validation.MINIMUM_LENGHT } };
        yield return new object[] { null, new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.EMPTY_NAME, DomainErrors.Validation.NULL_NAME } };
        yield return new object[] { "S", new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.MINIMUM_LENGHT } };
        yield return new object[] { "ffffffffffffffffffffffffffffffffffffffffffffffffff",new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.MAXIMUM_LENGHT } };
        yield return new object[] { "&Invalid@Name#", new List<BaseError> {DomainErrors.Validation.HALL_VALIDATION_FAILURE, DomainErrors.Validation.SPECIFIC_CHARACTERS } };
    }
    
    
    [Theory]
    [MemberData(nameof(HallData.InvalidNameData))]
    public void ValidateHall_InvalidName_ReturnsExpectedErrors(string name, List<BaseError> expectedErrors)
    {
        // Arrange
        var hall = CreateHall(Guid.NewGuid(), name, 50, 2500);

        // Act & Assert
        AssertInvalidHallResult(hall, expectedErrors);
    }
    private TResult<Hall> CreateHall(Guid? id, string name, int seats, decimal basePrice)
    {
        return Hall.Create(id, name, seats, basePrice);
    }
    private void AssertInvalidHallResult(TResult<Hall> hall, List<BaseError> expectedErrors)
    {
        Assert.Null(hall.Value);
        Assert.True(hall.IsFailure);
        Assert.False(hall.IsSuccess);
        Assert.Equal(expectedErrors.Count, hall.ErrorReasons.Count);

        foreach (var expectedError in expectedErrors)
        {
            Assert.Contains(hall.ErrorReasons, error => error.ErrorType == expectedError.ErrorType);
        }
    }
}