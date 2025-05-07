namespace Vulcano.Domain.Base;

public abstract class BaseEntity(Guid id)
{
    public Guid Id { get; protected set; } = id;
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
}
