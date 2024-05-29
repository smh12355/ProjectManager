﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Services;
using ProjectManager.Infrastructure;

namespace ProjectManager.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {

        services.AddScoped<IProjectsService, ProjectsService>();
        services.AddScoped<IDesignObjectsService, DesignObjectsService>();

        return services;
    }
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