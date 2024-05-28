using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using ProjectManager.Domain.Models;

namespace ProjectManager.Infrastructure.Repository;

public class TreesDataRepository
{
    private readonly ProjectManagerDbContext _context;

    public TreesDataRepository(ProjectManagerDbContext context)
    {
        _context = context;
    }

    public async Task<List<TreeDataAnother>> GetTree()
    {

        var projectEntities = await _context.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToListAsync();

        //var result = projectEntities
        //    .Select(a => new TreeDataAnother(a.Id, a.Name, a.DesignObjects.Id, a.DesignObjects.Name))
        //    .ToList();
        var result = projectEntities
            .SelectMany(a => a.DesignObjects.Select(b => new TreeDataAnother(a.Id, a.Name, b.Id, b.Name)))
            .ToList();
        //var projectIds = projectEntities
        //    .GroupBy(g => g.Id)
        //    .Select(a => a.Key)
        //    .ToList();

        //List<TreeData> result = new List<TreeData>();
        //foreach(var id in projectIds)
        //{
        //    var asd =  projectEntities
        //        .Where(a => a.Id == id)
        //        .Select(a => a.DesignObjects.Select(b => new DesignObjectsPerProject(b.Id,b.Name)))
        //        .ToList();
        //    var projectName = projectEntities
        //        .Where(a => a.Id == id)
        //        .Select(a => a.Name)
        //        .FirstOrDefault();
        //    result.Add(new TreeData(id, projectName, asd));
        //}
        return result;
    }
    public async Task<List<TreeDataAnother>> GetTreeMemberByProject()
    {

        var projectEntities = await _context.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToListAsync();

        //var result = projectEntities
        //    .Select(a => new TreeDataAnother(a.Id, a.Name, a.DesignObjects.Id, a.DesignObjects.Name))
        //    .ToList();
        var result = projectEntities
            .SelectMany(a => a.DesignObjects.Select(b => new TreeDataAnother(a.Id, a.Name, b.Id, b.Name)))
            .ToList();
        //var projectIds = projectEntities
        //    .GroupBy(g => g.Id)
        //    .Select(a => a.Key)
        //    .ToList();

        //List<TreeData> result = new List<TreeData>();
        //foreach(var id in projectIds)
        //{
        //    var asd =  projectEntities
        //        .Where(a => a.Id == id)
        //        .Select(a => a.DesignObjects.Select(b => new DesignObjectsPerProject(b.Id,b.Name)))
        //        .ToList();
        //    var projectName = projectEntities
        //        .Where(a => a.Id == id)
        //        .Select(a => a.Name)
        //        .FirstOrDefault();
        //    result.Add(new TreeData(id, projectName, asd));
        //}
        return result;
    }
}
