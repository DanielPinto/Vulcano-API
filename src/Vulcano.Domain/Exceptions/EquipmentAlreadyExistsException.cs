namespace Vulcano.Domain.Exceptions;

public class EquipmentAlreadyExistsException(string serial) : Exception($"Já existe um equipamento com o número de série '{serial}'.")
{
}
