using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Vulcano.Infrastructure.Persistence;

namespace Vulcano.Infrastructure.Extensions;

public static class DbContextConfiguration
{
    public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
        var environment = configuration["ENVIRONMENT"] ?? "production";

        bool useInMemory = string.IsNullOrEmpty(dbConnectionString) || environment is "dev" or "local";

        if (useInMemory)
        {
            Console.WriteLine("⚡ Usando banco InMemory para desenvolvimento.");
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("DevInMemoryDb"));
        }
        else
        {
            Console.WriteLine("🔗 Usando banco relacional (PostgreSQL).");
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(dbConnectionString));
        }

        return services;
    }
}
