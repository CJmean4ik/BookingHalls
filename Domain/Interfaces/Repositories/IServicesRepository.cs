using Domain.Models;
using Domain.Repositories.Splited;
using Domain.Shared.Utils;

namespace Domain.Repositories;

public interface IServicesRepository : ICreater<Service>, IUpdater<Service>, IReader<Service>
{
    Task<TResult<Service>> GetByIdAsync(Guid? id);
    Task<TResult<List<Service>>> GetByIdListAsync(List<Guid?> guids);
}