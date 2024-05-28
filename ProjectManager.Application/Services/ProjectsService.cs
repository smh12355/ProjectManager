using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Services;

public class ProjectsService : IProjectsService
{
    private readonly IProjectManagerDbContext _dbContext;

    public ProjectsService(IProjectManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .Select(a => new Project(a.Id, a.Cipher, a.Name))
            .ToListAsync();
    }

    public async Task<List<DesignObject>> GetDesignObjectsByProjectId(int projectId)
    {
        return await _dbContext.DesignObjects
            .AsNoTracking()
            .Where(a => a.ProjectId == projectId)
            .Select(a => new DesignObject(a.Id, a.ParentDesignObjectId, a.Code, a.Name))
            .ToListAsync();
    }
    public async Task<List<ProjectDetailsDto>> GetFullDataByClick(int id)
    {
        var includedEntities = await _dbContext.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ThenInclude(d => d.DocSets)
            .Where(a => a.Id == id)
            .Select(a => new ProjectDetailsDto(
                a.Id,
                a.Cipher,
                a.Name,
                a.DesignObjects.Select(b => new DesignObjectDetailsDto(
                    b.Id,
                    b.Name,
                    b.Code,
                    b.DocSets.Select(c => new DocSetDetailsDto(
                        c.Id,
                        c.Mark,
                        c.Number)).ToList()
                    )).ToList()
                    )).ToListAsync();
        return includedEntities;
    }
}
