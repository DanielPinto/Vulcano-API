using Vulcano.Domain.Entities;
using Vulcano.Domain.Interfaces;

namespace Vulcano.Infrastructure.Persistence;

public class InMemoryEquipmentRepository : IEquipmentRepository
{
    private readonly List<Equipment> _equipments = [];

    public Task AddAsync(Equipment equipment)
    {
        _equipments.Add(equipment);
        return Task.CompletedTask;
    }

    public Task<bool> ExistsBySerialAsync(string serial)
    {
        var exists = _equipments.Any(e => e.SerialNumber.Value.Equals(serial, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(exists);
    }

    public Task<IEnumerable<Equipment>> GetAllAsync()
    {
        return Task.FromResult(_equipments.AsEnumerable());
    }

    public Task<Equipment?> GetByIdAsync(Guid id)
    {
        var equipment = _equipments.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(equipment);
    }

    public Task UpdateAsync(Equipment equipment)
    {
        var index = _equipments.FindIndex(e => e.Id == equipment.Id);
        if (index >= 0)
        {
            _equipments[index] = equipment;
        }
        return Task.CompletedTask;
    }
}
