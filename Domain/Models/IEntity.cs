namespace Domain.Models;

public interface IEntity<T>
{
    public T Id { get; }
}