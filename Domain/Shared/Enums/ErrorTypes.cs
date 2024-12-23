namespace Domain.Shared.Enums;

public enum ErrorTypes
{
    NoError,
    GlobalError,
    ValueNull,
    EmptyValue,
    NotFounded,
    MinimumLimit,
    MaximumLimit,
    IncorrectValue,
    FailureValidation,
    SpecificCharacters,
    ZeroValue,
    InvalidOperation,
    BeginTransaction,
    CommitFailure,
    NotUnique,
    SaveChanges,
}