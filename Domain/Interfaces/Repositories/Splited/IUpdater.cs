using Domain.Models;
using Domain.Shared.Utils;

namespace Domain.Repositories.Splited
{
    public interface IUpdater<TEntity>
                where TEntity : class, IEntity<Guid?>
    {
        Task<Result> UpdateAsync(TEntity entity);
    }
}
