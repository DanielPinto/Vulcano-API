using System;
using FluentValidation;
using Vulcano.Application.DTOs;
using Vulcano.Domain.Interfaces;

namespace Vulcano.Application.Validators.EquipamentValidators;

public class CreateEquipamentDtoValidator : AbstractValidator<CreateEquipmentDto>
{
    public CreateEquipamentDtoValidator(IEquipmentRepository repository)
    {
       RuleFor(e => e.Name)
            .NotEmpty().WithMessage("O nome do equipamento é obrigatório.")
            .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

        RuleFor(e => e.SerialNumber)
            .NotEmpty().WithMessage("O número de série é obrigatório.")
            .Length(6, 20).WithMessage("O número de série deve ter entre 6 e 20 caracteres.");

        RuleFor(e => e.Type)
            .NotEmpty().WithMessage("O tipo do equipamento é obrigatório.")
            .MaximumLength(50).WithMessage("O tipo deve ter no máximo 50 caracteres.");

        RuleFor(e => e.CreatedAt)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("A data de aquisição não pode estar no futuro.");
    }
}