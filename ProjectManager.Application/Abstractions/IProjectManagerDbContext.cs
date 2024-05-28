using Microsoft.EntityFrameworkCore;
using ProjectManager.Infrastructure.Entities;

namespace ProjectManager.Application.Abstractions;

public interface IProjectManagerDbContext
{
    DbSet<ProjectEntity> Projects { get; set; }
    DbSet<DesignObjectEntity> DesignObjects { get; set; }
    DbSet<DocSetEntity> DocSets { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
