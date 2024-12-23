using Domain.Models;
using Domain.Repositories.Splited;

namespace Domain.Repositories;

public interface IBookedHallServicesRepository : 
    ICreater<BookedHallServices>,
    IDeleter<BookedHallServices>,
    IReader<BookedHallServices>
{
    
}