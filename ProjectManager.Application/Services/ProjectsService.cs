using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Common.Extensions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Contracts.Project;
using ProjectManager.Domain.Entities;
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

    public async Task<List<ProjectResponce>> GetList()
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .Select(a => new ProjectResponce(a.Id, a.Cipher, a.Name))
            .ToListAsync();
    }

    public async Task<ProjectResponce> GetById(int id)
    {
        return await _dbContext.Projects
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new ProjectResponce(a.Id, a.Cipher, a.Name))
            .FirstOrDefaultAsync();
    }

    public async Task<List<ProjectIncludingDesignObjectResponce>> GetInludingDesignObjects()
    {
        var responce = await _dbContext.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToListAsync();
        var somelist = new List<ProjectIncludingDesignObjectResponce>();
        foreach (var project in responce)
        {
            var somelist1 = new List<DesignObjectTreeResponce>();
            foreach (var designobject in project.DesignObjects)
            {
                if (designobject.ParentDesignObjectId == null)
                { 
                    somelist1.Add(MapChilds(designobject, project.DesignObjects.ToList()));
                }
            }
            somelist.Add(new ProjectIncludingDesignObjectResponce(project.Id,project.Cipher, project.Name, somelist1));
        }
        return somelist;
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
