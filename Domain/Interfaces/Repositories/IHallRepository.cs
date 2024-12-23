using Domain.Models;
using Domain.Repositories.Splited;
using Domain.Shared.Utils;

namespace Domain.Repositories;

public interface IHallRepository : ICreater<Hall>, IUpdater<Hall>, IDeleter<Hall>, IReader<Hall>
{
    Task<TResult<Hall>> GetById(Guid id);
}