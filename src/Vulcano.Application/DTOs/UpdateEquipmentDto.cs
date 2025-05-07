namespace Vulcano.Application.DTOs;
public class UpdateEquipmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
}
