using DataAccess.Contexts;
using Domain.Models;
using Domain.Repositories;
using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Domain.Shared.Utils;
using Domain.Shared.Static;
using Domain.Shared.Utils.TypesResults.ErrorsResults;
using Domain.Shared.Utils.TypesResults.SuccessResults;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class ServicesRepository : IServicesRepository
{
    private readonly BookingHallsContext _context;

    public ServicesRepository(BookingHallsContext context)
    {
        _context = context;
    }

    public async Task<TResult<Service>> CreateAsync(Service entity)
    {
        await _context.Services.AddAsync(entity);
        return Result.CreateSuccess(entity,DomainSuccess.Database.SERVICE_ADD);
    }

    public async Task<Result> UpdateAsync(Service entity)
    {
        var service = await _context.Services.Where(BaseSpecifications.HasById<Service>(entity.Id)).FirstOrDefaultAsync();
        if (service is null)
        {
            return Result.CreateFailure(DomainErrors.Database.NOT_FOUNDED_SERVICES);
        }

        _context.Attach(service).Property(p => p.Price).CurrentValue = entity.Price;
        _context.Attach(service).Property(p => p.Price).IsModified = true;
        return Result.CreateSuccess(DomainSuccess.Database.SERVICE_PRICE_CHANGING);
    }
    
    public async Task<TResult<List<Service>>> GetListAsync(int page, int limit)
    {
        var services = await _context.Services
            .AsNoTracking()
            .Skip((page - 1) * limit)
            .Take(limit)
            .ToListAsync();

        return Result.CreateSuccess(services, new OperationSuccess($"Services received, count: {services.Count}", SuccessTypes.Receive, OperationName.RECEIVE_SERVICES));
    }
    
    public async Task<TResult<Service>> GetByIdAsync(Guid? id)
    {
        var service = await _context.Services.Where(BaseSpecifications.HasById<Service>(id)).FirstOrDefaultAsync();
        if (service is null)
        {
            return Result.CreateFailure<Service>(DomainErrors.Database.NOT_FOUNDED_SERVICES);
        }

        return Result.CreateSuccess(service,new OperationSuccess("Service was found",SuccessTypes.Receive,OperationName.RECEIVE_SERVICES));
    }
    public async Task<TResult<List<Service>>> GetByIdListAsync(List<Guid?> guids)
    {
        if (guids == null)
        {
            return Result.CreateFailure<List<Service>>(DomainErrors.Operation.SERVICE_RECEIVE)
                .AddErrorReasons(DomainErrors.Validation.NULL_IDS);
        }
        
        var services = await _context.Services
            .Where(w => guids.Contains(w.Id))
            .ToListAsync();

        if (services.Count < guids.Count || services.Count == 0)
        {
            var missingGuids = guids
                .Where(g => !services.Any(s => s.Id == g))
                .ToList();
            
            return Result.CreateFailure<List<Service>>(DomainErrors.Operation.SERVICE_RECEIVE)
                .AddErrorReasons(new OperationError($"Some services were not found. Missing services: {missingGuids}",ErrorTypes.NotFounded,OperationName.RECEIVE_SERVICES));
        }

        return Result.CreateSuccess(services,new OperationSuccess("All services have been found",SuccessTypes.Receive,OperationName.RECEIVE_SERVICES));
    }
 
}