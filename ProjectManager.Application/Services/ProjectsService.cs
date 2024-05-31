using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Extensions;
using ProjectManager.Domain.Common.Extensions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Contracts.Project;
using ProjectManager.Domain.Entities;
using ProjectManager.Domain.Models;
using System.Linq;
using System.Net.Sockets;
using System.Text;

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
            .Select(a => new ProjectResponce(a.Id, a.Cipher, a.Name))
            .FirstOrDefaultAsync();
    public async Task<List<ProjectIncludingDesignObjectResponce>> GetListInludingDesignObjects()
    {
        var responce = await _dbContext.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToListAsync();
        var somelist = new List<ProjectIncludingDesignObjectResponce>();
        foreach (var item in responce)
        {
            var somelist1 = new List<DesignObjectTreeResponce>();
            foreach (var obj in item.DesignObjects)
            {
                somelist1.Add(MapChilds(obj, item.DesignObjects.ToList()));
            }
            somelist.Add(new ProjectIncludingDesignObjectResponce(item.Id,item.Cipher, item.Name, somelist1));
        }
        return somelist;
    }
    public async Task<ProjectDetailsDto> GetFullDataByClick(int id)
    {
        //var test = _dbContext.Projects
        //    .AsNoTracking()
        //    .SelectMany(project => project.DesignObjects
        //    .SelectMany(designObject => designObject.DocSets
        //    .Select(docSet => new ProjectIncludeAllObjects(
        //    project.Id,
        //    project.Cipher,
        //    project.Name,
        //    designObject.Id,
        //    designObject.Code,
        //    designObject.Name,
        //    docSet.Id,
        //    docSet.Mark,
        //    docSet.Number
        //    ))));

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

    public async Task<List<ProjectIncludeAllObjects>> GetListInludingAllEntities()
    {
        //var test = _dbContext.Projects
        //    .AsNoTracking()
        //    .SelectMany(project => project.DesignObjects
        //    .Select(x => new
        //    {
        //        Cipher = project.Cipher,
        //        FullCode = x.DesignObject != null 
        //        ? x.DesignObject.Code + "." + x.Code
        //        : x.Code
        //    })).ToList();
        var projects = _dbContext.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToList();
        //var projectsq = _dbContext.DesignObjects
        //    .AsNoTracking();

        var asd = projects.First().DesignObjects.ToList();
        var test = MapChilds(asd[0], asd);
        //var anotherprojects = _dbContext.DesignObjects
        //    .AsNoTracking()
        //    .IncludeAllParents(d => d.ParentDesignObject);
        //var mydatalist = new List<new { int Cipher, string FullCode } >();
        //var mydatalist = new List<(string Cipher, string FullCode)>();
        //foreach (var project in projects)
        //{
        //    foreach (var designOjbect in project.DesignObjects)
        //    {
        //        var fullCode = new StringBuilder();
        //        var indicate = designOjbect;
        //        if (indicate.ChildrenDesignObjects.Count is 0)
        //        {
        //            mydatalist.Add((project.Cipher, indicate.Code));
        //            continue;
        //        }
        //        else
        //        {
        //            while (indicate.ChildrenDesignObjects.Count is not 0)
        //            {
        //                fullCode.Append(indicate.Code);
        //                fullCode.Append('.');
        //                indicate = designOjbect.ParentDesignObject;
        //                foreach (var item in mydatalist)
        //                {

        //                }
        //            }
        //        }
        //        mydatalist.Add((project.Cipher, fullCode.ToString()));
        //    }
        //}
        //void somefunc(var1,var2,var3)
        //{

        //}
        return await _dbContext.Projects
            .AsNoTracking()
            .SelectMany(project => project.DesignObjects
            .SelectMany(designObject => designObject.DocSets
            .Select(docSet => new ProjectIncludeAllObjects(
            project.Id,
            project.Cipher,
            project.Name,
            designObject.Id,
            designObject.Code,
            designObject.Name,
            docSet.Id,
            docSet.Mark.ToString(),
            docSet.Mark.GetName(),
            docSet.Number
            )))).ToListAsync();
    }
    private static DesignObjectTreeResponce MapChilds(DesignObjectEntity parent, List<DesignObjectEntity> DesignObjects)
    {
        var Childs = new List<DesignObjectTreeResponce>();
        foreach (var item in DesignObjects)
        {
            if (item.ParentDesignObjectId == parent.Id) 
            {
                Childs.Add(MapChilds(item,DesignObjects));
            }
        }
        return new DesignObjectTreeResponce(parent.Id, parent.ParentDesignObjectId,parent.Code, Childs);
    }
}
