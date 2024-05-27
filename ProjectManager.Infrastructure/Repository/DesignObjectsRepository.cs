using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure.Entities;

namespace ProjectManager.Infrastructure.Repository;

public class DesignObjectsRepository : IDesignObjectsRepository
{
    private readonly ProjectManagerDbContext _context;

    public DesignObjectsRepository(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<DesignObject>> Get()
    {
        var designObjectsEntities = await _context.DesignObjects
         .AsNoTracking()
         .Include(a => a.DocSets)
         .ToListAsync();
        var designProjects = designObjectsEntities
            .Select(b => new DesignObject(b.Id, b.ProjectId, b.Code, b.Name))
            .ToList();
        return designProjects;
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
        await _context.DesignObjects.AddAsync(designObjectEntity);
        await _context.SaveChangesAsync();

        return designObjectEntity.Id;
    }

    public async Task<int> Update(int id, int projectId, string code, string name)
    {
        var designObject = await _context.DesignObjects.FindAsync(id);
        if (designObject is null)
        {
            throw new Exception("DesignObject not found");
        }

        designObject.Id = id;
        designObject.ProjectId = projectId;
        designObject.Code = code;
        designObject.Name = name;

        await _context.SaveChangesAsync();

        return designObject.Id;
    }

    public async Task<int> Delete(int id)
    {
        var designObject = await _context.DesignObjects.FindAsync(id);
        if (designObject is null)
        {
            throw new Exception("DesignObject not found");
        }

        _context.DesignObjects.Remove(designObject);
        await _context.SaveChangesAsync();

        return id;
    }
}
