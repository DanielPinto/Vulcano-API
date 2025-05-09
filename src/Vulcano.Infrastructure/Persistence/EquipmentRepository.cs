using Microsoft.EntityFrameworkCore;
using Vulcano.Domain.Entities;
using Vulcano.Domain.Interfaces;

namespace Vulcano.Infrastructure.Persistence;

public class EquipmentRepository : IEquipmentRepository
{
    private readonly AppDbContext _context;

    public EquipmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Equipment equipment)
    {
        await _context.Equipments.AddAsync(equipment);
        await _context.SaveChangesAsync();
    }

    public Task<bool> ExistsBySerialAsync(string serial)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Equipment>> GetAllAsync()
    {
        return await _context.Equipments.AsNoTracking().ToListAsync();
    }

    public async Task<Equipment?> GetByIdAsync(Guid id)
    {
        return await _context.Equipments.FindAsync(id);
    }

    public async Task UpdateAsync(Equipment equipment)
    {
        _context.Equipments.Update(equipment);
        await _context.SaveChangesAsync();
    }
}
