using Domain.Models;
using Domain.Shared.Utils;

namespace Domain.Repositories.Splited
{
    public interface ICreater<TEntity>
        where TEntity : class, IEntity<Guid?>
    {
        Task<TResult<TEntity>> CreateAsync(TEntity entity);
    }
}
