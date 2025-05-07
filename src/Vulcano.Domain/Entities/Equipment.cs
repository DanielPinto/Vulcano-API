using Vulcano.Domain.Base;
using Vulcano.Domain.Exceptions;
using Vulcano.Domain.ValueObjects;

namespace Vulcano.Domain.Entities;

public class Equipment(Guid Id, string name, string serialNumber, string type, DateTimeOffset purchaseDate) : BaseEntity(Id)
{
    public string Name { get; private set; } = name;
    public SerialNumber SerialNumber { get; private set; } = new SerialNumber(serialNumber);
    public string Type { get; private set; } = type;
    public DateTimeOffset PurchaseDate { get; private set; } = purchaseDate;

    public void Update(string name, string type, DateTime purchaseDate)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidEquipmentException();

        Name = name;
        Type = type;
        PurchaseDate = purchaseDate;
    }

}
