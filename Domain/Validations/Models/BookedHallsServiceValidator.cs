using Domain.Models;
using FluentValidation;

namespace Domain.Validations.Models;

public class BookedHallsServiceValidator : AbstractValidator<BookedHallServices>
{
    public BookedHallsServiceValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator());
        RuleFor(r => r.ServiceId).SetValidator(new IdValidator());
        RuleFor(r => r.BookedHallsId).SetValidator(new IdValidator());
    }
    
}