using Domain.Aggregates;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Validations;
using FluentValidation;

namespace Domain.Models;

public class Hall : IEntity<Guid?>
{
    private readonly List<BookedHall> _bookedHalls = new List<BookedHall>();
    private readonly List<AvailableHallServices> _avalaibleHallServices = new List<AvailableHallServices>();
    
    public IReadOnlyCollection<BookedHall> BookedHalls => _bookedHalls;
    public IReadOnlyCollection<AvailableHallServices> AvailableHallServices => _avalaibleHallServices;
    
    public Guid? Id { get; }
    public string Name { get; }
    public int Seats { get; }
    public decimal BasePricePerHour { get; }

    private Hall()
    {
        
    }
    private Hall(Guid? id, string name, int seats, decimal basePricePerHour)
    : this()
    {
        Id = id;
        Name = name;
        Seats = seats;
        BasePricePerHour = basePricePerHour;
    }
    
    public void AddBookedHalls(params BookedHall[] bookedHalls) => _bookedHalls.AddRange(bookedHalls);
    public void AddAvalaibleHallServices(params AvailableHallServices[] bookedHalls) => _avalaibleHallServices.AddRange(AvailableHallServices);
    
    public static TResult<Hall> Create(Guid? id, string name, int seats, decimal basePricePerHour, bool checkId = true)
    {
        var hall = new Hall(id, name, seats, basePricePerHour);

        IValidator<Hall> validator = new HallValidator();
        var result = validator.Validate(hall);
        if (!result.IsValid)
        {
            return Result.CreateFailure<Hall>(DomainErrors.Operation.HALL_CREATING)
                .AddValidationError(DomainErrors.Validation.HALL_VALIDATION_FAILURE, result.Errors);
        }
        
        return Result.CreateSuccess(hall, DomainSuccess.Operation.HALL_CREATING);
    }

   
}