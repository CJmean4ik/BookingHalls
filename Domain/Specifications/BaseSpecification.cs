using System.Linq.Expressions;
using Domain.Models;

namespace Domain.Specifications;

public class BaseSpecifications
{
    public static Expression<Func<T, bool>> HasById<T>(Guid? id) where T : IEntity<Guid?>
    {
        return entity => entity.Id == id;
    }
}