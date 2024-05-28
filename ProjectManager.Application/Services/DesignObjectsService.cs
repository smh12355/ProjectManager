using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Services;

public class DesignObjectsService : IDesignObjectsService
{
    private readonly IProjectManagerDbContext _dbContext;
    public DesignObjectsService(IProjectManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DesignObject>> GetByProjectId(int projectId)
    {
        return await _dbContext.DesignObjects
            .AsNoTracking()
            .Where(a => a.ProjectId == projectId)
            .Select(a => new DesignObject(a.Id, a.ParentDesignObjectId, a.Code, a.Name))
            .ToListAsync();
    }
}
