using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
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

#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
    public async Task<ProjectResponce> GetById(int id) => await _dbContext.Projects
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new ProjectResponce(a.Id, a.Cipher, a.Name))
            .FirstOrDefaultAsync();
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
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
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
#pragma warning disable CS8620 // Аргумент запрещено использовать для параметра из-за различий в отношении допустимости значений NULL для ссылочных типов.
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
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
            .ThenInclude(a => a.ChildrenDesignObjects)
            .ToList();
        //var mydatalist = new List<new { int Cipher, string FullCode } >();
        var mydatalist = new List<(string Cipher, string FullCode)>();
        foreach (var project in projects)
        {
            foreach (var designOjbect in project.DesignObjects)
            {
                var fullCode = new StringBuilder();
                var indicate = designOjbect;
                fullCode.Append(indicate.Code);
                while (indicate.ParentDesignObject is not null)
                {
                    indicate = designOjbect.ParentDesignObject;
                    fullCode.Append('.');
                    fullCode.Append(indicate.Code);
                }
                mydatalist.Add((project.Cipher, fullCode.ToString()));
            }
        }
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
            docSet.Mark.GetMark(),
            docSet.Number
            )))).ToListAsync();
    }
#pragma warning restore CS8603 // Возможно, возврат ссылки, допускающей значение NULL.
#pragma warning restore CS8620 // Аргумент запрещено использовать для параметра из-за различий в отношении допустимости значений NULL для ссылочных типов.
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

}
