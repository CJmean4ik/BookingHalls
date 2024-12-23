using Domain.Shared;

namespace Domain.Models;

public class User : IEntity<Guid?>
{
    public Guid? Id { get; init; }
    public string HashedPassword { get; init; }
    public string SaltPassword { get; init; }

    protected User()
    {
        
    }
    protected User(Guid? id, string hashPassword, string saltPassword)
    {
        Id = id;
        HashedPassword = hashPassword;
        SaltPassword = saltPassword;
    }
}