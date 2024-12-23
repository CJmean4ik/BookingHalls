using Domain.Models;
using Domain.Repositories.Splited;

namespace Domain.Repositories;

public interface IBookerRepository : ICreater<Booker>, IReader<Booker>
{
    
}