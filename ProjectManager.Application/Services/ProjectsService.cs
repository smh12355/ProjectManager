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

    public async Task<List<DesignObject>> GetProjectDesignObjects(int id)
    {
        return await _dbContext.DesignObjects
            .AsNoTracking()
            .Where(a => a.ProjectId == id)
            .Select(a => new DesignObject(a.Id, a.ParentDesignObjectId, a.Code, a.Name))
            .ToListAsync();
    }
    //public async Task<List<>> GetFullDataByClick(int id)
    //{
    //    return await _dbContext.Projects
    //        .AsNoTracking()
    //        .Select(a => new Project(a.Id, a.Cipher, a.Name))
    //        .ToListAsync();
    //}
}
