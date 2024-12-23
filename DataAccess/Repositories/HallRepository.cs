using DataAccess.Contexts;
using Domain.Models;
using Domain.Repositories;
using Domain.Shared.Constants;
using Domain.Shared.Enums;
using Domain.Shared.Static;
using Domain.Shared.Utils;
using Domain.Shared.Utils.TypesResults.SuccessResults;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class HallRepository : IHallRepository
{
    private readonly BookingHallsContext _context;
    public HallRepository(BookingHallsContext context)
    {
        _context = context;
    }
    
    public async Task<TResult<Hall>> CreateAsync(Hall entity)
    {
        await _context.Halls.AddAsync(entity);
        return Result.CreateSuccess(entity, DomainSuccess.Database.HALL_ADD);
    }
    public async Task<Result> UpdateAsync(Hall entity)
    {
       var oldHall = await _context.Halls.Where(BaseSpecifications.HasById<Hall>(entity.Id)).FirstOrDefaultAsync();
       if (oldHall is null)
           return Result.CreateFailure(DomainErrors.Database.NOT_FOUND_HALL);

       _context.Entry(oldHall).Property(p => p.Name).CurrentValue = entity.Name;
       _context.Entry(oldHall).Property(p => p.BasePricePerHour).CurrentValue = entity.BasePricePerHour;
       _context.Entry(oldHall).Property(p => p.Name).IsModified = true;
       _context.Entry(oldHall).Property(p => p.BasePricePerHour).IsModified = true;
       
       return Result.CreateSuccess(DomainSuccess.Database.HALL_UPDATING);
    }
    public async Task<Result> DeleteAsync(Hall entity)
    {
        var oldHall = await _context.Halls.Where(BaseSpecifications.HasById<Hall>(entity.Id)).FirstOrDefaultAsync();
        if (oldHall is null)
            return Result.CreateFailure(DomainErrors.Database.NOT_FOUND_HALL);

        _context.Halls.Remove(oldHall);
        return Result.CreateSuccess(DomainSuccess.Database.HALL_DELETING);
    }
    public async Task<TResult<List<Hall>>> GetListAsync(int page, int limit)
    {
        var halls = await _context.Halls
            .AsNoTracking()
            .Skip((page - 1) * limit)
            .Take(limit)
            .Include(i => i.AvailableHallServices)
            .ThenInclude(i => i.Service)
            .ToListAsync();

        return Result.CreateSuccess(halls, 
            new OperationSuccess($"Hall received, count: {halls.Count}", SuccessTypes.Receive, OperationName.RECEIVE_HALL));
    }
    public async Task<TResult<Hall>> GetById(Guid id)
    {
        var hall = await _context.Halls.Where(BaseSpecifications.HasById<Hall>(id)).FirstOrDefaultAsync();
        if (hall is null)
            return Result.CreateFailure<Hall>(DomainErrors.Database.NOT_FOUND_HALL);

        return Result.CreateSuccess(hall, new OperationSuccess($"Hall received,", SuccessTypes.Receive, OperationName.RECEIVE_HALL));
    }
}