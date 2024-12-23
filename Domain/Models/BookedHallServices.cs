using Domain.Aggregates;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Validations.Models;
using FluentValidation;

namespace Domain.Models;

public class BookedHallServices: IEntity<Guid?>
{
    public Guid? Id { get; }
    
    public Guid? BookedHallsId { get; }
    public BookedHall? BookedHalls { get; }

    public Guid? ServiceId { get; }
    public Service? Service { get; }

    private BookedHallServices()
    {
        
    }
    private BookedHallServices(Guid? id, Guid bookedHallsId, Guid serviceId)
     :this()
    {
        Id = id;
        BookedHallsId = bookedHallsId;
        ServiceId = serviceId;
    }

    public static TResult<BookedHallServices> Create(Guid? id,  Guid bookedHallsId, Guid serviceId, bool checkId = true)
    {
        var bookedHallServices = new BookedHallServices(id, bookedHallsId, serviceId);

        IValidator<BookedHallServices> validator = new BookedHallsServiceValidator();
        var result = validator.Validate(bookedHallServices);
        if (!result.IsValid)
        {
            return Result.CreateFailure<BookedHallServices>(DomainErrors.Operation.BOOKEDHALLSERVICE_CREATING)
                .AddValidationError(DomainErrors.Validation.HALL_VALIDATION_FAILURE, result.Errors);
        }
        return Result.CreateSuccess(bookedHallServices, DomainSuccess.Operation.BOOKEDHALLSERIVCES_CREATING);
    }
}