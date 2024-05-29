using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Entities;
using System.Reflection;

namespace ProjectManager.Infrastructure;

public class ProjectManagerDbContext : DbContext, IProjectManagerDbContext
{
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
    public ProjectManagerDbContext(DbContextOptions<ProjectManagerDbContext> options) : base(options)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
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
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}
