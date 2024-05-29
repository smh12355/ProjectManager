using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProjectManager.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServicesInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ProjectManagerDbContext>(
            options =>
            {
                var connetionString = configuration.GetConnectionString("DefaultConnection");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });

        services.AddScoped<IProjectManagerDbContext>(provider => provider.GetRequiredService<ProjectManagerDbContext>());

        return services;
    }
}
