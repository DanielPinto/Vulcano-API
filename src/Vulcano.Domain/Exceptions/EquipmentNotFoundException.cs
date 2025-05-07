namespace Vulcano.Domain.Exceptions;

public class EquipmentNotFoundException(Guid id) : Exception($"Equipamento id: {id} não encontrado.")
{
}