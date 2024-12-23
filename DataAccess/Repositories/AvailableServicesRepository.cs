using DataAccess.Contexts;
using Domain.Models;
using Domain.Repositories;
using Domain.Shared.Static;
using Domain.Shared.Utils;

namespace DataAccess.Repositories;

public class AvailableServicesRepository : IAvailableServicesRepository
{
    private readonly BookingHallsContext _context;

    public AvailableServicesRepository(BookingHallsContext context)
    {
        _context = context;
    }

    public Task<TResult<AvailableHallServices>> CreateAsync(AvailableHallServices entity)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeleteAsync(AvailableHallServices iD)
    {
        throw new NotImplementedException();
    }

    public Task<TResult<List<AvailableHallServices>>> GetListAsync(int page, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<TResult<AvailableHallServices>> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<TResult<List<AvailableHallServices>>> CreateRangeAsync(List<AvailableHallServices> entity)
    {
        await _context.AvailableHallServices.AddRangeAsync(entity);
        return Result.CreateSuccess(entity,DomainSuccess.Database.AVAILABLESERVICE_ADD);
    }

    public Task<TResult<List<AvailableHallServices>>> GetByIdListAsync(List<Guid> guids)
    {
        throw new NotImplementedException();
    }
}