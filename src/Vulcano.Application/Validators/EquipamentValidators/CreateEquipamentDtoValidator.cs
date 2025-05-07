using System;
using FluentValidation;
using Vulcano.Application.DTOs;
using Vulcano.Domain.Interfaces;

namespace Vulcano.Application.Validators.EquipamentValidators;

public class CreateEquipamentDtoValidator : AbstractValidator<CreateEquipmentDto>
{
    public CreateEquipamentDtoValidator(IEquipmentRepository repository)
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("O nome é obrigatório.");

        RuleFor(x => x.SerialNumber)
            .NotEmpty().WithMessage("O serial é obrigatório.")
            .MustAsync(async (serial, _) => !await repository.ExistsBySerialAsync(serial))
            .WithMessage("Já existe um equipamento com esse serial.");
    }
}