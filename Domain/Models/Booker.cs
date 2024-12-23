using Domain.Aggregates;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Validations.Models;
using FluentValidation;

namespace Domain.Models;

public class Booker : User
{
    private readonly List<BookedHall> _bookedHalls = new List<BookedHall>();
    public string Name { get; }
    public string Surname { get; }
    public string Email { get; }
    
    public IReadOnlyCollection<BookedHall> BookedHalls => _bookedHalls;
    public void AddBookedHalls(params BookedHall[] bookedHalls) => _bookedHalls.AddRange(bookedHalls);

    private Booker() 
        : base()
    {
        
    }
    private Booker(string hashPassword, string saltPassword, string name, string lastName, string email, Guid? id = null) 
        : base(id, hashPassword, saltPassword)
    {
        Name = name;
        Surname = lastName;
        Email = email;
    }
    
    public static TResult<Booker> Create(Guid? id, string hashPassword, string saltPassword, string name, string surname, string email, bool checkId = true)
    {
        var booker = new Booker(hashPassword,saltPassword,name,surname,email,id);

        IValidator<Booker> validator = new BookerValidator();
        var result = validator.Validate(booker);
        if (!result.IsValid)
        {
            return Result.CreateFailure<Booker>(DomainErrors.Operation.BOOKER_CREATING)
                .AddValidationError(DomainErrors.Validation.BOOKER_VALIDATION_FAILURE,result.Errors);
        }
        return Result.CreateSuccess(booker, DomainSuccess.Operation.BOOKER_CREATING);
    }
}