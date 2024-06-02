using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Contracts.DocSet;
using ProjectManager.Domain.Entities;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ProjectManager.Application.Services;

public class DocSetService : IDocSetService
{
    private readonly IProjectManagerDbContext _projectManagerDbContext;

    public DocSetService(IProjectManagerDbContext projectManagerDbContext)
    {
        _projectManagerDbContext = projectManagerDbContext;
    }

    public async Task<List<DocSetByProjectResponce>> GetByProject(int projectId)
    {
        var allEntitiesLinked = await _projectManagerDbContext
            .Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ThenInclude(a => a.DocSets)
            .Where(a => a.Id == projectId)
            .ToListAsync();

        var result = new List<DocSetByProjectResponce>();
        foreach (var project in allEntitiesLinked)
        {
            foreach (var designObject in project.DesignObjects)
            {
                var counter = 0;
                foreach (var docSet in designObject.DocSets)
                {
                    var fullCode = MapFullCode(designObject, project.DesignObjects.ToList()).ToString();
                    var markPlusNumber = string.Concat(docSet.Mark.ToString(), $"{counter}");
                    result.Add(new DocSetByProjectResponce(project.Cipher,
                                                             fullCode,
                                                             docSet.Mark.ToString(),
                                                             markPlusNumber,
                                                             string.Concat(project.Cipher, fullCode, markPlusNumber)));
                    counter++;
                }
            }
        }
        return result;
    }

    public async Task<List<DocSetByProjectResponce>> GetByDesignObject(int designObjectId)
    {
        var linkedEntities = await _projectManagerDbContext
            .DesignObjects
            .Include(a => a.Project)
            .Include(b => b.DocSets)
            .ToListAsync();

        var parent = linkedEntities
            .Where(a => a.Id == designObjectId)
            .FirstOrDefault();

        var treeByParent = MapDesignObjectsTree(parent);
        var result = new List<DocSetByProjectResponce>();
        foreach (var designObject in treeByParent)
        {
            var counter = 0;
            foreach (var docSet in designObject.DocSets)
            {
                var fullcode = MapFullCode(designObject, linkedEntities).ToString();
                var marcplusnumber = string.Concat(docSet.Mark.ToString(), $"{counter}");
                result.Add(new DocSetByProjectResponce(designObject.Project.Cipher,
                                                         fullcode,
                                                         docSet.Mark.ToString(),
                                                         marcplusnumber,
                                                         string.Concat(designObject.Project.Cipher, fullcode, marcplusnumber)));
            }
        }
        return result;
    }

    private static StringBuilder MapFullCode(DesignObjectEntity parent, List<DesignObjectEntity> DesignObjects)
    {
        var Code = new StringBuilder();
        if (parent.ParentDesignObjectId != null)
        {
            foreach (var item in DesignObjects)
            {
                if (parent.ParentDesignObjectId == item.Id)
                {
                    Code.Append(MapFullCode(item, DesignObjects));
                    break;
                }
            }
        }
        Code.Append(parent.Code);
        return Code;
    }
    private static List<DesignObjectEntity> MapDesignObjectsTree(DesignObjectEntity parent)
    {
        var childs = new List<DesignObjectEntity>();
        if (parent.ChildrenDesignObjects != null)
        {
            foreach (var item in parent.ChildrenDesignObjects)
            {
                childs.AddRange(MapDesignObjectsTree(item));
            }
        }
        childs.Add(parent);
        return childs;
    }

}
