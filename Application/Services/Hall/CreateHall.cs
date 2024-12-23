using Application.Requests.Hall;
using Domain.Contracts;
using Domain.Models;
using Domain.Repositories;
using Domain.Shared.Static;
using Domain.Shared.Utils;

namespace Application.Services.Hall;

public class CreateHall
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHallRepository _hallRepository;
    private readonly IAvailableServicesRepository _availableServicesRepository;
    private readonly IServicesRepository _servicesRepository;

    public CreateHall(IUnitOfWork unitOfWork, IHallRepository hallRepository, IAvailableServicesRepository availableServicesRepository, IServicesRepository servicesRepository)
    {
        _unitOfWork = unitOfWork;
        _hallRepository = hallRepository;
        _availableServicesRepository = availableServicesRepository;
        _servicesRepository = servicesRepository;
    }
    public async Task<TResult<Domain.Models.Hall>> CreateAsync(CreateHallRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _unitOfWork.BeginTransactionAsync();
        if (result.IsFailure)
        {
            return result.CopyToTResult<Domain.Models.Hall>(result);
        }
        
        var hallResult = Domain.Models.Hall.Create(Guid.NewGuid(), request.Name, request.Seats, request.BasePrice,false);
        if (hallResult.IsFailure)
        {
            return hallResult.CopyToTResult<Domain.Models.Hall>(hallResult);
        }
        
        var creatingHallResult = await _hallRepository.CreateAsync(hallResult.Value!);
        if (creatingHallResult.IsFailure)
        {
            return creatingHallResult.CopyToTResult<Domain.Models.Hall>(creatingHallResult);
        }
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (!request.WithoutServices)
        {
            var hallServicesResult = await CreateAvailableHallServices(request, hallResult.Value!.Id);
            if (hallServicesResult.IsFailure) return hallServicesResult.CopyToTResult<Domain.Models.Hall>(hallServicesResult);
            
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        
        var resultUoW = await _unitOfWork.CommitTransactionAsync();
        if (resultUoW.IsFailure)
        {
            return resultUoW.CopyToTResult<Domain.Models.Hall>(resultUoW);
        }
        

        return Result.CreateSuccess(creatingHallResult.Value!,DomainSuccess.Operation.HALL_CREATING);
    }
    private async Task<Result> CreateAvailableHallServices(CreateHallRequest request,Guid? hallId)
    {
        var servicesResult = await _servicesRepository.GetByIdListAsync(request.Services);
        if (servicesResult.IsFailure)
        {
            return servicesResult;
        }

        var availableServices = servicesResult.Value
            .Select(s => AvailableHallServices
                .Create(Guid.NewGuid(), hallId, s.Id,true).Value)
            .ToList();
            
        var creatingAvailableServiceResult = await _availableServicesRepository.CreateRangeAsync(availableServices);
        if (creatingAvailableServiceResult.IsFailure)
        {
            return creatingAvailableServiceResult;
        }

        return Result.CreateSuccess(DomainSuccess.Operation.AVAILABLESERVICE_CREATING);
    }
}