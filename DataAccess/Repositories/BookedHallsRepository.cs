using DataAccess.Contexts;
using Domain.Aggregates;
using Domain.Shared.Utils;
using Domain.Shared.Enums;
using Domain.Shared.Static;
using Domain.Specifications;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class BookedHallsRepository : IBookedHallsRepository
{
    private readonly BookingHallsContext _context;

    public BookedHallsRepository(BookingHallsContext context)
    {
        _context = context;
    }

    public async Task<TResult<BookedHall>> CreateAsync(BookedHall entity)
    {
        var isAvailable = await _context.BookedHalls
            .Include(w => w.Hall)
            .Where(BookedHallsSpecifications.AvailableForBooking)
            .Where(BookedHallsSpecifications.IsAvailableAtTime(entity.TimeStart))
            .AnyAsync();

        if (!isAvailable)
        {
           return Result.CreateFailure<BookedHall>(DomainErrors.Database.BOOKEDHALL_CREATE)
               .AddErrorReasons(DomainErrors.Validation.INCORRECT_DATE);
        }
        
        entity.SetStatus(BookingStatus.Created);
        await _context.BookedHalls.AddAsync(entity);
        return Result.CreateSuccess(entity, DomainSuccess.Database.BOOKEDHALL_ADD);
    }

    public Task<Result> UpdateAsync(BookedHall entity)
    {
        throw new NotImplementedException();
    }

    public Task<TResult<List<BookedHall>>> GetListAsync(int page, int limit)
    {
        throw new NotImplementedException();
    }

    public Task<Result> UpdateBookedHallsStatus(BookingStatus status)
    {
        throw new NotImplementedException();
    }
    
}