using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Requests.Hall;


public class CreateHallRequest
{
    public string Name { get; set; }
    public int Seats { get; set; }
    public decimal BasePrice { get; set; }
    public List<Guid?> Services { get; set; } = new List<Guid?>();
    
    [NotMapped] public bool WithoutServices => Services.Count == 0;
}