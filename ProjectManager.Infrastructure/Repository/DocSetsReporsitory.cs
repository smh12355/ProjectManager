using Microsoft.EntityFrameworkCore;
using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure.Entities;

namespace ProjectManager.Infrastructure.Repository;

public class DocSetsReporsitory : IDocSetsReporsitory
{
    private readonly ProjectManagerDbContext _context;

    public DocSetsReporsitory(ProjectManagerDbContext context)
    {
        _context = context;
    }
    public async Task<List<DocSet>> Get()
    {
        var docSetEntities = await _context.DocSets
         .AsNoTracking()
         .ToListAsync();
        var docSets = docSetEntities
            .Select(b => new DocSet(b.Id, b.DesignObjectId, b.Mark, b.Number))
            .ToList();
        return docSets;
    }

    public async Task<int> Create(DocSet docSet)
    {
        var docSetEntity = new DocSetEntity
        {
            Id = docSet.Id,
            DesignObjectId = docSet.DesignObjectId,
            Mark = docSet.Mark,
            Number = docSet.Number
        };
        await _context.DocSets.AddAsync(docSetEntity);
        await _context.SaveChangesAsync();
        return docSetEntity.Id;
    }

    public async Task<int> Update(int id, int designObjectId, Mark mark, int Number)
    {
        var docSet = await _context.DocSets.FindAsync(id);
        if (docSet is null)
        {
            throw new Exception("DocSet not found");
        }

        docSet.Id = id;
        docSet.DesignObjectId = designObjectId;
        docSet.Mark = mark;
        docSet.Number = Number;

        await _context.SaveChangesAsync();

        return docSet.Id;
    }

    public async Task<int> Delete(int id)
    {
        var docSet = await _context.DocSets.FindAsync(id);
        if (docSet is null)
        {
            throw new Exception("DocSet not found");
        }

        _context.DocSets.Remove(docSet);
        await _context.SaveChangesAsync();

        return id;
    }
}
