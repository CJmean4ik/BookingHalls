using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Validations.Models;
using FluentValidation;

namespace Domain.Models;

public class Service : IEntity<Guid?>
{
    private readonly List<BookedHallServices> _bookedHallServices = new List<BookedHallServices>();
    private readonly List<AvailableHallServices> _availableHallServices = new List<AvailableHallServices>();

    public IReadOnlyCollection<BookedHallServices> BookedHallServices => _bookedHallServices;
    public IReadOnlyCollection<AvailableHallServices> AvailableHallServices => _availableHallServices;
    
    public Guid? Id { get; }
    public string Name { get; }
    public decimal Price { get; }
    
    public void AddBookedHallServices(params BookedHallServices[] bookedHallServices) => _bookedHallServices.AddRange(bookedHallServices);
    public void AddAvalaibleHallServices(params AvailableHallServices[] avalaibleHallServices) => _availableHallServices.AddRange(avalaibleHallServices);

    private Service()
    {
        
    }
    private Service(Guid? id, string name, decimal price)
    : this()
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public static TResult<Service> Create(Guid? id, string name, decimal price)
    {
        var service = new Service(id, name, price);

        IValidator<Service> validator = new ServicesValidator();
        var result = validator.Validate(service);
        if (!result.IsValid)
        {
            return Result.CreateFailure<Service>(DomainErrors.Operation.SERVICE_CREATING)
                .AddValidationError(DomainErrors.Validation.SERVICE_VALIDATION_FAILURE, result.Errors);
        }
        
        return Result.CreateSuccess(service, DomainSuccess.Operation.SERVICE_CREATING);
    }
}