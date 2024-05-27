using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Models.Projects;
using ProjectManager.Infrastructure;

namespace ProjectManager.Application.Services;

public class ProjectRepo
{
    private readonly ProjectManagerDbContext _context;

    public ProjectRepo(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<GetProjectsResponse> Get()
    {
        var projectEntities = await _context.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToListAsync();
        var books = projectEntities
            .Select(a => a.)
    }
}
