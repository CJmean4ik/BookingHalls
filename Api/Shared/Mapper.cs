using Api.Responces;
using Domain.Models;

namespace Api.Shared;

public static class Mapper
{
    public static HallResponce FromHallToHallResponce(Hall hall)
    {
       return new HallResponce()
        {
            Id = hall.Id,
            Name = hall.Name,
            Seats = hall.Seats,
            BasePricePerHour = hall.BasePricePerHour,
            AvailableHallServices = hall.AvailableHallServices.Select(s => new AvailableHallServicesResponce
            {
                Id = s.Service.Id,
                Name = s.Service.Name,
                Price = s.Service.Price
            }).ToList()
        };
    }
}