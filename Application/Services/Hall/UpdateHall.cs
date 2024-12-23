using Domain.Contracts;
using Domain.Repositories;
using Domain.Shared.Utils;

namespace Application.Services.Hall;

public class UpdateHall
{
    private IUnitOfWork _unitOfWork;
    private IHallRepository _hallRepository;
    private IAvailableServicesRepository _availableServicesRepository;
    private IServicesRepository _servicesRepository;

    public UpdateHall(IUnitOfWork unitOfWork, 
        IHallRepository hallRepository,
        IAvailableServicesRepository availableServicesRepository,
        IServicesRepository servicesRepository)
    {
        _unitOfWork = unitOfWork;
        _hallRepository = hallRepository;
        _availableServicesRepository = availableServicesRepository;
        _servicesRepository = servicesRepository;
    }

    public async Task<Result> UpdateAsync()
    {
        var transactionResult = await _unitOfWork.BeginTransactionAsync();
        if (transactionResult.IsFailure)
            return transactionResult;
        
        
        
    }
}