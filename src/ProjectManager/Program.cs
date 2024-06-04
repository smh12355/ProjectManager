using ProjectManager.Infrastructure;
using ProjectManager.Application;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Filters;

namespace ProjectManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //контроллеры
        builder.Services.AddControllers();
        //swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //db и сервисы
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddApplicationServices();

        builder.Services.AddScoped<ProjectNotFoundFilter>();
        //builder.Services.AddControllers(options =>
        //{
        //    options.Filters.Add<Filters.NotFoundFilter>();
        //});
        builder.Services.AddControllers(options =>
        {
            options.Filters.Add<ExceptionFilter>();
        });
        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var context = services.GetRequiredService<ProjectManagerDbContext>(); // «амените на ваш DbContext
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while migrating or initializing the database.");
            }
        }
        // смотрим launchSettings.json
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();
    }
}
