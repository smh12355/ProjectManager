using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure.Entities;

namespace ProjectManager.Infrastructure.Repository;

public class DocSetRepository
{
    private readonly ProjectManagerDbContext _context;

    public DocSetRepository(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<DocSet>> Get()
    {
        var docSetEntities = await _context.DocSets
         .AsNoTracking()
         .ToListAsync();
        var projects = docSetEntities
            .Select(b => new DocSet(b.Id, b.DesignObjectId, b.Mark, b.Number))
            .ToList();
        return projects;
    }

    public async Task<int> Create(DesignObject designObject)
    {
        var designObjectEntity = new DesignObjectEntity
        {
            Id = designObject.Id,
            ProjectId = designObject.ProjectId,
            Code = designObject.Code,
            Name = designObject.Name
        };
        await _context.AddAsync(designObjectEntity);
        await _context.SaveChangesAsync();

        return designObjectEntity.Id;
    }

    public async Task<int> Update(int id, int projectId, string code, string name)
    {
        var designProject = await _context.DesignObjects.FindAsync(id);
        if (designProject is null)
        {
            throw new Exception("designProject not found");
        }

        designProject.Id = id;
        designProject.ProjectId = projectId;
        designProject.Code = code;
        designProject.Name = name;

        await _context.SaveChangesAsync();

        return designProject.Id;
    }

    public async Task<int> Delete(int id)
    {
        var designProject = await _context.DesignObjects.FindAsync(id);
        if (designProject is null)
        {
            throw new Exception("designProject not found");
        }

        _context.DesignObjects.Remove(designProject);
        await _context.SaveChangesAsync();

        return id;
    }
}
