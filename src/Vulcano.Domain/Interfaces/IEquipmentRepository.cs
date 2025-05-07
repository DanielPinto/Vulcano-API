using Vulcano.Domain.Entities;

namespace Vulcano.Domain.Interfaces;

public interface IEquipmentRepository
{
    Task AddAsync(Equipment equipment);
    Task<IEnumerable<Equipment>> GetAllAsync();
    Task<Equipment?> GetByIdAsync(Guid id);
    Task UpdateAsync(Equipment equipment);
    Task<bool> ExistsBySerialAsync(string serial);

}
