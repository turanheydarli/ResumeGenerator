namespace Domain.Common;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
}