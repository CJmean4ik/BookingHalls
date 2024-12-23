using Domain.Models;
using Domain.Repositories.Splited;
using Domain.Shared.Utils;

namespace Domain.Repositories;

public interface IAvailableServicesRepository : 
    ICreater<AvailableHallServices>,
    IDeleter<AvailableHallServices>,
    IReader<AvailableHallServices>
{
    Task<TResult<AvailableHallServices>> GetByIdAsync(Guid id);
    Task<TResult<List<AvailableHallServices>>> CreateRangeAsync(List<AvailableHallServices> entity);
    Task<TResult<List<AvailableHallServices>>> GetByIdListAsync(List<Guid> guids);
}