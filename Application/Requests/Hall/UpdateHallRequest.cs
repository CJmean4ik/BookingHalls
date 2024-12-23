namespace Application.Requests.Hall;

public class UpdateHallRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Seats { get; set; }
    public decimal BasePrice { get; set; }
    
}