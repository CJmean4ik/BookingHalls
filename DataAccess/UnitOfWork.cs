using DataAccess.Contexts;
using Domain.Contracts;
using Domain.Shared.Constants;
using Domain.Shared.Utils;
using Domain.Shared.Extensions;
using Domain.Shared.Static;
using Microsoft.EntityFrameworkCore.Storage;
using Serilog;

namespace DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookingHallsContext _context;
    private IDbContextTransaction _transaction;

    public Result? ErrorResult { get; set; }

    public bool IsSuccessChangeSaved => ErrorResult is null ? false : true;


    public UnitOfWork(BookingHallsContext context)
    {
        _context = context;
    }

    public async Task<Result> BeginTransactionAsync()
    {
        if (_transaction != null)
           return Result.CreateFailure(DomainErrors.Database.TRANSACTION_STARTED);

        _transaction = await _context.Database.BeginTransactionAsync();
        return Result.CreateSuccess(DomainSuccess.Database.TRANSACTION_STARTED);
    }
    public async Task<Result> CommitTransactionAsync()
    {
        try
        {
            if (_transaction == null)
                return Result.CreateFailure(DomainErrors.Database.COMMIT_TRANSACTION)
                    .AddErrorReasons(DomainErrors.Database.NO_TRANSACTION);
            
            await _transaction.CommitAsync();
            return Result.CreateSuccess(DomainSuccess.Database.COMMIT_TRANSACTION);
        }
        catch (Exception ex)
        {
            await _transaction.RollbackAsync();
            Log.Error(ex.Message);
            return Result.CreateFailure(DomainErrors.Database.COMMIT_TRANSACTION).AddException(ex,OperationName.COMMIT_TRANSACTION);
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
            return Result.CreateSuccess(DomainSuccess.Database.SAVECHANGES);
        }
        catch (Exception ex)
        {
            await _transaction.RollbackAsync();
            Log.Error(ex.Message);
            
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
            return Result.CreateFailure(DomainErrors.Database.SAVECHANGES)
                .AddException(ex,OperationName.SAVECHANGES);
        }
    }
}