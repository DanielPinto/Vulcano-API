using System.Reflection.Metadata.Ecma335;
using Vulcano.Application.DTOs;
using Vulcano.Domain.Entities;
using Vulcano.Domain.Exceptions;
using Vulcano.Domain.Interfaces;
using Vulcano.Domain.Utils;

namespace Vulcano.Application.UseCases.EquipmentUseCase
{
    public class EquipmentHandler(IEquipmentRepository repository)
    {
        private readonly IEquipmentRepository _repository = repository;

        public async Task<Result<CreateEquipmentDto>> CreateAsync(CreateEquipmentDto dto)
        {
            var existing = await _repository.GetAllAsync();
            if (existing.Any(e => e.SerialNumber.ToString() == dto.SerialNumber))
                throw new EquipmentAlreadyExistsException(dto.SerialNumber);

            var equipment = new Equipment( dto.Id,dto.Name, dto.SerialNumber, dto.Type, dto.CreatedAt);
            await _repository.AddAsync(equipment);

            return Result<CreateEquipmentDto>.Success(dto);
        }

        public async Task UpdateAsync(UpdateEquipmentDto dto)
        {
            var equipment = await _repository.GetByIdAsync(dto.Id)
                ?? throw new EquipmentNotFoundException(dto.Id);

            equipment.Update(dto.Name, dto.Type, dto.PurchaseDate);

            await _repository.UpdateAsync(equipment);
        }

    }
}