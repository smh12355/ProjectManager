using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure;

namespace ProjectManager.Application.Services;

public class DesignObjectsService : IDesignObjectsService
{
    private readonly IProjectManagerDbContext _dbContext;
    public DesignObjectsService(IProjectManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<DesignObjectResponce>> GetByProjectId(int projectId) => await _dbContext.DesignObjects
            .AsNoTracking()
            .Where(a => a.ProjectId == projectId)
            .Select(a => new DesignObjectResponce(a.Id, a.ParentDesignObjectId, a.Code, a.Name))
            .ToListAsync();
}
