using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Services;

namespace ProjectManager.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IProjectsService, ProjectsService>();
        services.AddScoped<IDesignObjectsService, DesignObjectsService>();

        return services;
    }
}
