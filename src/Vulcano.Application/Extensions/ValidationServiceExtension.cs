using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Vulcano.Application.DTOs;
using Vulcano.Application.Validators.EquipamentValidators;

namespace Vulcano.Application.Extensions
{
    public static class ValidationServiceExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {

            services.AddValidatorsFromAssemblyContaining<CreateEquipmentDto>();
            //inserir demais Validators
            return services;
        }
    }
}


