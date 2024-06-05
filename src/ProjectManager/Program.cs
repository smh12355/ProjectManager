using ProjectManager.Infrastructure;
using ProjectManager.Application;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Filters;
using NLog.Web;

namespace ProjectManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var startup = new Startup(builder.Configuration, builder.Environment);

        startup.ConfigureServices(builder.Services);

        var app = builder.Build();

        startup.Configure(app);

        app.Run();
    }
}
