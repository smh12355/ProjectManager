using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Contracts.Project;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure;

namespace ProjectManager.Application.Services;

public class ProjectsService : IProjectsService
{
    private readonly IProjectManagerDbContext _dbContext;

    public ProjectsService(IProjectManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProjectResponce>> GetList() => await _dbContext.Projects
            .AsNoTracking()
            .Select(a => new ProjectResponce(a.Id, a.Cipher, a.Name))
            .ToListAsync();

    public async Task<ProjectResponce> GetById(int id) => await _dbContext.Projects
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new ProjectResponce(a.Id, a.Cipher,a.Name))
            .FirstOrDefaultAsync();

    public async Task<List<ProjectIncludingDesignObjectResponce>> GetListInludingDesignObjects() => await _dbContext.Projects
            .AsNoTracking()
            .Select(a => new ProjectIncludingDesignObjectResponce(
                a.Id,
                a.Name,
                a.Cipher,
                a.DesignObjects.Select(b => new DesignObjectResponce(
                    b.Id,
                    b.ParentDesignObjectId,
                    b.Code,
                    b.Name)).ToList()
                )).ToListAsync();
    
    public async Task<ProjectDetailsDto> GetFullDataByClick(int id)
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
                    )).FirstOrDefaultAsync();
        return includedEntities;
    }

}
