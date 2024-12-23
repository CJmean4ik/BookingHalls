using Domain.Shared.Utils;

namespace Domain.Repositories.Splited
{
    public interface IDeleter<TID>
    {
        Task<Result> DeleteAsync(TID iD);
    }
}
