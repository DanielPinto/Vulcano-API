namespace Vulcano.Application.DTOs;

public class CreateEquipmentDto
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
    public string Name { get; set; } = null!;
    public string SerialNumber { get; set; } = null!;
    public string Type { get; set; } = null!;
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
}
