using Domain.Shared;
using Domain.Shared.Utils;

namespace Domain.Contracts;

public interface IUnitOfWork
{
    Task<Result> CommitTransactionAsync();
    Task<Result> BeginTransactionAsync();
    Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}