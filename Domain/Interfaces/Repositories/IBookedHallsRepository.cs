using Domain.Aggregates;
using Domain.Repositories.Splited;
using Domain.Shared.Enums;
using Domain.Shared.Utils;

namespace DataAccess.Repositories;

public interface IBookedHallsRepository : ICreater<BookedHall>, IUpdater<BookedHall>, IReader<BookedHall>
{
    Task<Result> UpdateBookedHallsStatus(BookingStatus status);
}