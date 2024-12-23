using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Validations.Models;

namespace Domain.Models;

public class AvailableHallServices : IEntity<Guid?>
{
    public Guid? Id { get; init; }
    
    public Guid? HallId { get; set; }
    public Hall? Hall { get; set; }
    
    public Guid? ServiceId { get; set; }
    public Service? Service { get; set; }

    private AvailableHallServices()
    {
    }
    private AvailableHallServices(Guid? id,  Guid? hallId, Guid? serviceId)
    : this()
    {
        Id = id;
        HallId = hallId;
        ServiceId = serviceId;
    }

    public static TResult<AvailableHallServices> Create(Guid? id, Guid? hallId,Guid? serviceId, bool checkId = true)
    {
        var availableHallServices = new AvailableHallServices(id, hallId, serviceId);
        var validator = new AvailableHallServiceValidator();
        var result = validator.Validate(availableHallServices);
        if (!result.IsValid)
        {
            return  Result.CreateFailure<AvailableHallServices>(DomainErrors.Operation.AVAILABLESERVICE_CREATING)
                .AddValidationError(DomainErrors.Validation.AVAILABLEHALLSERVICE_VALIDATION_FAILURE,result.Errors);
        }
        
        return Result.CreateSuccess(availableHallServices, DomainSuccess.Operation.AVAILABLESERVICE_CREATING);
    }
}