using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Vulcano.Application.DTOs;

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


