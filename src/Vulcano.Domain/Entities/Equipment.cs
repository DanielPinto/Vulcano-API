using Vulcano.Domain.Base;
using Vulcano.Domain.Exceptions;
using Vulcano.Domain.ValueObjects;

namespace Vulcano.Domain.Entities;

public class Equipment : BaseEntity
{
    // ⚠️ EF Core requer este construtor sem parâmetros
    private Equipment() : base(Guid.Empty) { }

    public Equipment(Guid id, string name, string serialNumber, string type, DateTimeOffset purchaseDate)
        : base(id)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidEquipmentException();

        Name = name;
        SerialNumber = new SerialNumber(serialNumber);
        Type = type;
        PurchaseDate = purchaseDate;
    }

    public string Name { get; private set; } = null!;
    public SerialNumber SerialNumber { get; private set; } = null!;
    public string Type { get; private set; } = null!;
    public DateTimeOffset PurchaseDate { get; private set; }

    public void Update(string name, string type, DateTimeOffset purchaseDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidEquipmentException();

        Name = name;
        Type = type;
        PurchaseDate = purchaseDate;
    }
}
