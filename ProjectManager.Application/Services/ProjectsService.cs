using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Services;

public class ProjectsService : IProjectsService
{
    private readonly IProjectManagerDbContext _dbContext;

    public ProjectsService(IProjectManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<int> CreateProject(Project project)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteProject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .Select(a => new Project(a.Id,a.Cipher,a.Name))
            .ToListAsync();
    }

    public Task<int> UpdateProject(int id, string cipher, string name)
    {
        throw new NotImplementedException();
    }
}
