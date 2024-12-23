using Domain.Models;
using Domain.Providers;
using Domain.Shared.Utils;
using Domain.Shared.Enums;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Domain.Validations.Models;

namespace Domain.Aggregates;

public class BookedHall : IEntity<Guid?>
{
    private readonly List<BookedHallServices> _bookedHallServices = new List<BookedHallServices>();
    private BookingStatus _bookingStatus;
    private int _duration;
    private decimal _price;
    
    public Guid? Id { get; init; }
    public DateOnly DateStart { get; init; }
    public TimeOnly TimeStart { get; init; }
    public TimeOnly TimeEnd { get; init; }
    
    public Guid? HallId { get; init; }
    public Hall? Hall { get; init; }
    
    public Guid? BookerId { get; init; }
    public Booker? Booker { get; init; }
    public decimal Price => _price;
    public int Duration => _duration;
    public BookingStatus BookingStatus => _bookingStatus;
    public IReadOnlyCollection<BookedHallServices> BookedHallServices => _bookedHallServices;
    
    public BookedHall()
    {
        
    }
    public BookedHall(Guid? id, DateOnly dateStart, TimeOnly timeStart, TimeOnly timeEnd, Guid? hallId, Guid? bookerId)
    {
        Id = id;
        DateStart = dateStart;
        TimeStart = timeStart;
        TimeEnd = timeEnd;
        HallId = hallId;
        BookerId = bookerId;
    }

    public void AddBookedHallServices(params BookedHallServices[] bookedHallServices) => _bookedHallServices.AddRange(bookedHallServices);
    public void SetStatus(BookingStatus bookingStatus) => _bookingStatus = bookingStatus;
    public static TResult<BookedHall> Create(Guid? id, DateOnly dateStart, TimeOnly timeStart, TimeOnly timeEnd, Guid? hallId, Guid? bookerId, bool checkId = true)
    {
        var bookedHall = new BookedHall(id, dateStart, timeStart, timeEnd, hallId, bookerId);
        var validator = new BookedHallsValidator();
        var result = validator.Validate(bookedHall);
        if (!result.IsValid)
        {
            return Result.CreateFailure<BookedHall>(DomainErrors.Operation.BOOKEDHALL_CREATING)
                .AddValidationError(DomainErrors.Validation.BOOKEDHALL_VALIDATION_FAILURE,result.Errors);
        }
        
        return Result.CreateSuccess(bookedHall, DomainSuccess.Operation.BOOKEDHALL_CREATING);
    }
    public void CalculateDuration()
    {
        TimeSpan start = TimeStart.ToTimeSpan();
        TimeSpan end = TimeEnd.ToTimeSpan();

        var differenceTime = end - start;
        _duration = (int)differenceTime.TotalHours;
    }
    
    public void CalculatePrice(List<Service> services)
    {
        _price = TotalPriceCalculator.CalculatePrice(services,TimeStart, Hall.BasePricePerHour,_duration);
    }
    
}