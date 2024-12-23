using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Domain.Shared.Utils.TypesResults;
using Domain.Shared.Utils.TypesResults.SuccessResults;

namespace Domain.Shared.Static;

public class DomainSuccess
{
    /// <summary>
    ///  Success operations that relate directly to business logic and its behavior
    /// </summary>
    public static class Operation
    {
        public static readonly BaseSuccess HALL_CREATING = new OperationSuccess("Hall successfully created", SuccessTypes.Create, OperationName.CREATE_HALL);
        public static readonly BaseSuccess BOOKER_CREATING = new OperationSuccess("Booker successfully created", SuccessTypes.Create, OperationName.CREATE_BOOKER);
        public static readonly BaseSuccess SERVICE_CREATING = new OperationSuccess("Service successfully created", SuccessTypes.Create, OperationName.CREATE_SERVICES);
        public static readonly BaseSuccess BOOKEDHALL_CREATING = new OperationSuccess("Booked hall successfully created", SuccessTypes.Create, OperationName.CREATE_BOOKEDHALL);
        public static readonly BaseSuccess BOOKEDHALLSERIVCES_CREATING = new OperationSuccess("Booked hall services successfully created", SuccessTypes.Create, OperationName.CREATE_BOOKEDHALLSERVICE);
        public static readonly BaseSuccess AVAILABLESERVICE_CREATING = new OperationSuccess("Available hall service successfully created", SuccessTypes.Create, OperationName.CREATE_AVAILABLEHALLSERVICE);
    }
    
    /// <summary>
    /// Operations that occur on the database
    /// </summary>
    public static class Database
    {
        public static readonly BaseSuccess HALL_ADD = new OperationSuccess("Hall successfully created",SuccessTypes.Create,OperationName.CREATE_HALL);
        public static readonly BaseSuccess HALL_UPDATING = new OperationSuccess("Hall successfully updated",SuccessTypes.Update,OperationName.UPDATE_HALL);
        public static readonly BaseSuccess HALL_DELETING = new OperationSuccess("Hall successfully deleted",SuccessTypes.Delete,OperationName.DELETE_HALL);
        
        public static readonly BaseSuccess SERVICE_ADD = new OperationSuccess("Service successfully created",SuccessTypes.Create,OperationName.CREATE_SERVICES);
        public static readonly BaseSuccess SERVICE_FOUND = new OperationSuccess("Service was found", SuccessTypes.Receive, OperationName.SEARCH_SERVICES);
       
        public static readonly BaseSuccess AVAILABLESERVICE_ADD = new OperationSuccess("Available services have been added", SuccessTypes.Create, OperationName.CREATE_AVAILABLEHALLSERVICE);
        
        public static readonly BaseSuccess BOOKEDHALL_ADD = new OperationSuccess("Bookedhall successfully created. The booking was successful", SuccessTypes.Create, OperationName.CREATE_BOOKEDHALL);
        public static readonly BaseSuccess SERVICE_PRICE_CHANGING = new OperationSuccess("The price has been successfully changed", SuccessTypes.Update, OperationName.UPDATE_SERVICES);
        
        
        public static readonly BaseSuccess TRANSACTION_STARTED = new OperationSuccess("The transaction has been successfully started", SuccessTypes.StartedTransaction, OperationName.TRANSACTION);
        public static readonly BaseSuccess COMMIT_TRANSACTION = new OperationSuccess("Successfully to commit the transaction", SuccessTypes.Commit,OperationName.COMMIT_TRANSACTION);
        public static readonly BaseSuccess SAVECHANGES = new OperationSuccess("The changes were saved successfully", SuccessTypes.SaveChanges, OperationName.SAVECHANGES);
     //   public static readonly BaseSuccess NO_TRANSACTION = new OperationSuccess("No active transaction to commit", ErrorTypes.ValueNull, OperationName.COMMIT_TRANSACTION);

        
    }
}