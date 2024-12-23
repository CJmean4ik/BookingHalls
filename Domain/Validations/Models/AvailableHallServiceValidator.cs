using Domain.Models;
using FluentValidation;

namespace Domain.Validations.Models;

public class AvailableHallServiceValidator : AbstractValidator<AvailableHallServices>
{
    public AvailableHallServiceValidator()
    {
        RuleFor(r => r.Id).SetValidator(new IdValidator());
        RuleFor(r => r.ServiceId).SetValidator(new IdValidator());
        RuleFor(r => r.HallId).SetValidator(new IdValidator());
    }
    
}