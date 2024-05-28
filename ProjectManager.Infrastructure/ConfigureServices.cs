using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Abstractions;
using System;

namespace ProjectManager.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
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
