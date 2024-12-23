using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Domain.Shared.Utils.TypesResults;
using Domain.Shared.Utils.TypesResults.ErrorsResults;

namespace Domain.Shared.Static;


public static class DomainErrors
{
    /// <summary>
    /// Contains predefined fields with the results of domain model validation errors
    /// </summary>
   public static class Validation
   {
       
        public static readonly BaseError NULL_IDS = new ValidationError("The list with the id turned out to be null or empty", ErrorTypes.ValueNull);
        public static readonly BaseError NULL_ID = new ValidationError("The id must not be null", ErrorTypes.ValueNull);
        public static readonly BaseError EMPTY_ID = new ValidationError("The id must not be empty",ErrorTypes.EmptyValue);
        
        public static readonly BaseError EMPTY_NAME = new ValidationError("The name must not be empty",ErrorTypes.EmptyValue);
        public static readonly BaseError NULL_NAME = new ValidationError("The name must not be null",ErrorTypes.ValueNull);
        
        public static readonly BaseError EMPTY_SURNAME = new ValidationError("The surname must not be null",ErrorTypes.ValueNull);
        public static readonly BaseError NULL_SURNAME = new ValidationError("The surname must not be empty", ErrorTypes.EmptyValue);
        
        public static readonly BaseError NULL_PASSWORD = new ValidationError("The password must not be null", ErrorTypes.ValueNull);
        public static readonly BaseError EMPTY_PASSWORD = new ValidationError("The password must not be empty",ErrorTypes.EmptyValue);

        
        public static readonly BaseError EMPTY_EMAIL = new ValidationError("The email must not be null",ErrorTypes.ValueNull);
        public static readonly BaseError NULL_EMAIL = new ValidationError("The email must not be empty", ErrorTypes.EmptyValue);
        public static readonly BaseError INCORRECT_EMAIL = new ValidationError($"An incorrect email was entered",ErrorTypes.IncorrectValue);
        
        public static readonly BaseError ZERO_SEATS = new ValidationError("Hall cannot contains 0 seats",ErrorTypes.ZeroValue);
        public static readonly BaseError ZERO_PRICE = new ValidationError("Price cannot equal 0",ErrorTypes.ZeroValue);

        public static readonly BaseError MINIMUM_LENGHT = new ValidationError("The value must be greater than or equal to the minimum allowed", ErrorTypes.MinimumLimit);
        public static readonly BaseError MAXIMUM_LENGHT = new ValidationError("The value must be less than or equal to the maximum allowed", ErrorTypes.MaximumLimit);
        
        public static readonly BaseError INVALID_PASSWORD = new ValidationError("The presence of at least one capital letter (A-Z).\n" +
                                                                     "The presence of at least one lowercase letter (a-z).\n" +
                                                                     "The presence of at least one digit (0-9).\n" +
                                                                     "The presence of at least one special character (!@#$%^&*).", ErrorTypes.IncorrectValue);

        public static readonly BaseError PASSWORD_HASH_IS_NULL = new ValidationError("The hashed password must not be null",ErrorTypes.ValueNull);
        public static readonly BaseError PASSWORD_HASH_IS_EMPTY = new ValidationError("The hashed password must not be empty",ErrorTypes.EmptyValue);
        public static readonly BaseError PASSWORD_HASH_NOT_UNIQUE = new ValidationError("The hashed password is only not unique",ErrorTypes.NotUnique);
        public static readonly BaseError PASSWORD_HASH_INCORRECT_FORMAT = new ValidationError("The hashed password is incorrect format",ErrorTypes.IncorrectValue);
        
        public static readonly BaseError PASSWORD_SALT_IS_NULL = new ValidationError("The password salt must not be null",ErrorTypes.ValueNull);
        public static readonly BaseError PASSWORD_SALT_IS_EMPTY = new ValidationError("The password salt must not be empty",ErrorTypes.EmptyValue);
        
        public static readonly BaseError SPECIFIC_CHARACTERS = new ValidationError("The value must not contain special characters (! . , ? * & ^ % $ # @)",ErrorTypes.SpecificCharacters);
        
        public static readonly BaseError BOOKER_VALIDATION_FAILURE = new ValidationError("Booker validation was not successful",ErrorTypes.FailureValidation);
        public static readonly BaseError USER_VALIDATION_FAILURE = new ValidationError("User validation was not successful",ErrorTypes.FailureValidation);
        public static readonly BaseError HALL_VALIDATION_FAILURE = new ValidationError("Hall validation was not successful",ErrorTypes.FailureValidation);
        public static readonly BaseError AVAILABLEHALLSERVICE_VALIDATION_FAILURE =new ValidationError("AvailableHallServices validation was not successful",ErrorTypes.FailureValidation);
        public static readonly BaseError SERVICE_VALIDATION_FAILURE = new ValidationError("Service validation was not successful",ErrorTypes.FailureValidation);
        public static readonly BaseError BOOKEDHALL_VALIDATION_FAILURE = new ValidationError("BookedHall validation was not successful",ErrorTypes.FailureValidation);
        
        
        public static readonly BaseError INCORRECT_DATE = new ValidationError("The date of the conference is not correct. The booking time must be free",ErrorTypes.IncorrectValue);
        public static readonly BaseError INCORRECT_TIME_DIFFERENCE_BETWEEN = new ValidationError("The difference between the beginning of time and the end is incorrect",ErrorTypes.IncorrectValue);
        public static readonly BaseError INACTIVE_TIME_RANGE = new ValidationError("The time should not be in the inactive range from 23:00 to 6:00",ErrorTypes.IncorrectValue);
        public static readonly BaseError SHORT_BOOKING_TIME = new ValidationError("Short booking time. The reservation must be an hour or more",ErrorTypes.IncorrectValue);
   }
    
    /// <summary>
    /// Contains predefined fields with the results of operation errors
    /// </summary>
   public static class Operation
   {
       public static readonly BaseError HALL_CREATING = new OperationError("Failed to create hall", ErrorTypes.InvalidOperation, OperationName.CREATE_HALL);
       public static readonly BaseError BOOKER_CREATING = new OperationError("Failed to create booker", ErrorTypes.InvalidOperation,OperationName.CREATE_BOOKER);
       public static readonly BaseError SERVICE_CREATING = new OperationError("Failed to create services", ErrorTypes.InvalidOperation, OperationName.CREATE_SERVICES);
       public static readonly BaseError BOOKEDHALL_CREATING = new OperationError("Failed to booking hall", ErrorTypes.InvalidOperation, OperationName.CREATE_BOOKEDHALL);
       public static readonly BaseError AVAILABLESERVICE_CREATING = new OperationError("Failed to create availabe hall service", ErrorTypes.InvalidOperation, OperationName.CREATE_AVAILABLEHALLSERVICE);
       public static readonly BaseError BOOKEDHALLSERVICE_CREATING = new OperationError("Failed to create booked hall service", ErrorTypes.InvalidOperation, OperationName.CREATE_BOOKEDHALLSERVICE);
       
       public static readonly BaseError SERVICE_RECEIVE = new OperationError("Couldn't get available services", ErrorTypes.InvalidOperation, OperationName.RECEIVE_SERVICES);

       
    }

    /// <summary>
    /// Contains predefined fields with error results when working with the database
    /// </summary>
   public static class Database
   {
       public static readonly BaseError TRANSACTION_STARTED = new OperationError("The transaction has already started", ErrorTypes.BeginTransaction, OperationName.TRANSACTION);
       public static readonly BaseError COMMIT_TRANSACTION = new OperationError("Failed to commit the transaction", ErrorTypes.CommitFailure,OperationName.COMMIT_TRANSACTION);
       public static readonly BaseError NO_TRANSACTION = new OperationError("No active transaction to commit", ErrorTypes.ValueNull, OperationName.COMMIT_TRANSACTION);
       public static readonly BaseError SAVECHANGES = new OperationError("The changes could not be saved", ErrorTypes.SaveChanges, OperationName.SAVECHANGES);
       
       public static readonly BaseError NOT_FOUND_HALL = new OperationError("This hall not founded by id", ErrorTypes.NotFounded, OperationName.SEARCH_HALL);
       public static readonly BaseError NOT_FOUND_BOOKEDHALL = new OperationError("This booked hall not founded by id", ErrorTypes.NotFounded, OperationName.SEARCH_SERVICES);
       public static readonly BaseError NOT_FOUNDED_SERVICES = new OperationError("This service not founded by id", ErrorTypes.NotFounded, OperationName.SEARCH_SERVICES);
       
       public static readonly BaseError BOOKEDHALL_CREATE = new OperationError("Failed to make a booking", ErrorTypes.InvalidOperation, OperationName.CREATE_BOOKEDHALL);
   }
}