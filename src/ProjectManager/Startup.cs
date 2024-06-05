using Microsoft.Extensions.Configuration;
using ProjectManager.Filters;
using ProjectManager.Infrastructure;
using ProjectManager.Application;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Extensions.Logging;

namespace ProjectManager;

public class Startup
{
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            loggingBuilder.AddNLog("nlog.config");
        });
        // Контроллеры
        services.AddControllers();

        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        // DB и сервисы
        services.AddInfrastructureServices(_configuration);
        services.AddApplicationServices();

        services.AddControllers(options =>
        {
            options.Filters.Add<ExceptionFilter>();
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ProjectManagerDbContext>(); // Замените на ваш DbContext
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Startup>>();
                logger.LogError(ex, "An error occurred while migrating or initializing the database.");
            }
        }

        // Смотрим launchSettings.json
        if (_environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
