﻿using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Abstractions;

public interface IProjectManagerDbContext
{
    DbSet<DesignObjectEntity> DesignObjects { get; set; }
    DbSet<DocSetEntity> DocSets { get; set; }
    DbSet<ProjectEntity> Projects { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}