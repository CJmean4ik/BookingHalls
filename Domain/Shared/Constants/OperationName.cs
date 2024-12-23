namespace Domain.Shared.Constants;

/// <summary>
/// Contains constants with the name of the operations.
/// Operations relate to: business logic, databases, services, infrastructure, and APIs
/// </summary>
public class OperationName
{
    #region Database
    
        public const string TRANSACTION = "Database.Transaction";
        public const string COMMIT_TRANSACTION = "Database.Transaction.Commit";
        public const string SAVECHANGES = "Database.SaveChanges";

        #region Add
            public const string ADD_HALL = "Database.Hall.Add";
            public const string ADD_SERVICES = "Database.Service.Add";
            public const string ADD_BOOKEDHALL  = "Database.BookedHall.Add";
        #endregion

        #region Update
            public const string UPDATE_HALL = "Database.Hall.Update";
            public const string UPDATE_SERVICES = "Database.Services.Update";
            public const string UPDATE_BOOKEDHALL  = "Database.BookedHall.Update";
        #endregion
        
        #region Delete
            public const string DELETE_HALL = "Database.Hall.Delete";
            public const string DELETE_SERVICES = "Database.Services.Delete";
        #endregion

        #region Search
            public const string SEARCH_HALL = "Hall.Search";
            public const string SEARCH_SERVICES = "Database.Services.Search";
            public const string SEARCH_BOOKEDHALLS = "Database.BookedHall.Search";
        #endregion

        #region Receive
            public const string RECEIVE_HALL = "Hall.Get.One";
            public const string RECEIVE_LIMIT_HALL = "Hall.Get.Limit";
            public const string RECEIVE_SERVICES = "Database.Services.Get.One";
            public const string RECEIVE_LIMIT_SERVICES = "Database.Services.Get.Limit";
            public const string RECEIVE_BOOKEDHALL = "Database.BookedHall.Get.One";
            public const string RECEIVE_LIMIT_BOOKEDHALLS = "Database.BookedHall.Get.Limit";
        #endregion
        
    #endregion

    #region Domain
        public const string CREATE_HALL = "Hall.Create";
        public const string CREATE_SERVICES = "Services.Create";
        public const string CREATE_BOOKEDHALL = "BookedHall.Create";
        public const string CREATE_BOOKER = "Booker.Create";
        public const string CREATE_BOOKEDHALLSERVICE = "BookedHallService.Create";
        public const string CREATE_AVAILABLEHALLSERVICE = "AvailableHallService.Create";
    #endregion
    
    #region General
        public const string VALIDATION = "Model.Validation";
        
    #endregion
}