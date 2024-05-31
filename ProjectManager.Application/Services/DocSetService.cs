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

    //public async Task<int> Get()
    public async Task<List<DocSetByProjectResponce>> GetByProject(int ProjectId)
    {
        var responce = await _projectManagerDbContext
            .Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ThenInclude(a => a.DocSets)
            .Where(a => a.Id == ProjectId)
            .ToListAsync();
        var somelist = new List<DocSetByProjectResponce>();
        foreach (var project in responce)
        {
            foreach (var designobject in project.DesignObjects)
            {
                var counter = 0;
                foreach (var docset in designobject.DocSets)
                {
                    var fullcode = MapFullCode(designobject, project.DesignObjects.ToList()).ToString();
                    var marcplusnumber = string.Concat(docset.Mark.ToString(), $"{counter}");
                    somelist.Add(new DocSetByProjectResponce(project.Cipher,
                                                             fullcode,
                                                             docset.Mark.ToString(),
                                                             marcplusnumber,
                                                             string.Concat(project.Cipher, fullcode, marcplusnumber)));



                    counter+=1;
                }
            }
        }
        return somelist;
    }

    public async Task<List<DocSetByProjectResponce>> GetByDesignObject(int DesignObjectId)
    {
        var responce = await _projectManagerDbContext
            .Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects.Where(b => b.Id == DesignObjectId))
            .ThenInclude(a => a.DocSets)
            .ToListAsync();
        var responce1 = await _projectManagerDbContext
            .DesignObjects
            .ToListAsync();
        var somelist = new List<DocSetByProjectResponce>();
        foreach (var project in responce)
        {
            foreach (var designobject in project.DesignObjects)
            {
                var counter = 0;
                foreach (var docset in designobject.DocSets)
                {
                    var fullcode = MapFullCode(designobject, responce1).ToString();
                    var marcplusnumber = string.Concat(docset.Mark.ToString(), $"{counter}");
                    somelist.Add(new DocSetByProjectResponce(project.Cipher,
                                                             fullcode,
                                                             docset.Mark.ToString(),
                                                             marcplusnumber,
                                                             string.Concat(project.Cipher, fullcode, marcplusnumber)));



                    counter += 1;
                }
            }
        }
        return somelist;
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

}
