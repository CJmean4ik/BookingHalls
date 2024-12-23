using Domain.Models;
using Domain.Shared.Utils;

namespace Domain.Repositories.Splited
{
    public interface IReader<TEntity> where TEntity 
        : class, IEntity<Guid?>
    {
        Task<TResult<List<TEntity>>> GetListAsync(int page, int limit);

    }
}
