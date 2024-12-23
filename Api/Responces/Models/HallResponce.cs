using Domain.Models;

namespace Api.Responces;

public class HallResponce
{
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public int? Seats { get; set; }
        public decimal? BasePricePerHour { get; set; }
        public List<AvailableHallServicesResponce>? AvailableHallServices { get; set; }
}