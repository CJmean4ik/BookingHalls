using System.Linq.Expressions;
using Domain.Aggregates;
using Domain.Shared.Enums;

namespace Domain.Specifications;

public class BookedHallsSpecifications
{
    public static Expression<Func<BookedHall,bool>> AvailableForBooking =
        hall => hall.BookingStatus == BookingStatus.Created || hall.BookingStatus == BookingStatus.Postponed;
    
    public static Expression<Func<BookedHall,bool>> IsAvailableAtTime(TimeOnly timeStart) => 
        hall => hall.TimeEnd <= timeStart;

}