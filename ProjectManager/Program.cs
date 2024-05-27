using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Abstractions;
using ProjectManager.Infrastructure;
using ProjectManager.Infrastructure.Repository;

namespace ProjectManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProjectManagerDbContext>(
               options =>
               {
                   var connetionString = builder.Configuration.GetConnectionString("DefaultConnection");
                   options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
               });
            builder.Services.AddScoped<IProjectsService, ProjectsService>();
            builder.Services.AddScoped<IProjectsRepository, ProjectsRepository>();
            builder.Services.AddScoped<IDesignObjectsService, DesignObjectsService>();
            builder.Services.AddScoped<IDesignObjectsRepository, DesignObjectsRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
