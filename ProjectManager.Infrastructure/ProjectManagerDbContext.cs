using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Infrastructure.Entities;
using System.Reflection;

namespace ProjectManager.Infrastructure;

public class ProjectManagerDbContext : DbContext, IProjectManagerDbContext
{
    public ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options) : base(options)
    {
    }
    public DbSet<ProjectEntity> Projects { get; set; }
    public DbSet<DesignObjectEntity> DesignObjects { get; set; }
    public DbSet<DocSetEntity> DocSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
