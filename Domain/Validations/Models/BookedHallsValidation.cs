using Domain.Aggregates;
using Domain.Shared.Constants;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using FluentValidation;

namespace Domain.Validations.Models;

public class BookedHallsValidator : AbstractValidator<BookedHall>
{

    public BookedHallsValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator()); 
        ValidateDateStart();
        ValidateDateTimeStartAndEnd();
    }
    
    private void ValidateDateStart()
    {
        RuleFor(r => r.DateStart)
            .LessThan(Validation.DATE_NOW).WithError(DomainErrors.Validation.INCORRECT_DATE);
    }
    private void ValidateDateTimeStartAndEnd()
    {
        RuleFor(r => r.TimeStart)
            .LessThan(booked => booked.TimeEnd).WithError(DomainErrors.Validation.INCORRECT_DATE);

        
        RuleFor(r => new {r.TimeStart, r.TimeEnd})
            .Must(bookedHalls => IsTimeWithinInactivePeriod(bookedHalls.TimeStart, bookedHalls.TimeEnd))
            .WithError(DomainErrors.Validation.INCORRECT_DATE);
        
        
              RuleFor(booking => booking)
            .Must(booking => (booking.TimeEnd - booking.TimeStart) >= TimeSpan.FromHours(1))
            .WithError(DomainErrors.Validation.SHORT_BOOKING_TIME);
    }
    private bool IsTimeWithinInactivePeriod(TimeOnly timeStart, TimeOnly timeEnd)
    {
        return (timeStart > TimePeriods.InactiveStart || timeStart < TimePeriods.InactiveEnd) ||
               (timeEnd > TimePeriods.InactiveStart || timeEnd < TimePeriods.InactiveEnd);
    }
}