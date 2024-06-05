using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Exceptions;
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
        var result = await _dbContext.Projects
            .AsNoTracking()
            .Where(a => a.Id == id)
            .Select(a => new ProjectResponce(a.Id, a.Cipher, a.Name))
            .FirstOrDefaultAsync();

        if (result is null)
        {
            throw new ProjectNotExistException($"project with id:{id} does not exist");
        }

        return result;
    }

    public async Task<List<ProjectIncludingDesignObjectResponce>> GetInludingDesignObjects()
    {
        var responce = await _dbContext.Projects
            .AsNoTracking()
            .Include(a => a.DesignObjects)
            .ToListAsync();
        var result = new List<ProjectIncludingDesignObjectResponce>();
        foreach (var project in responce)
        {
            var tree = new List<DesignObjectTreeResponce>();
            foreach (var designobject in project.DesignObjects)
            {
                if (designobject.ParentDesignObjectId == null)
                { 
                    tree.Add(MapChilds(designobject, project.DesignObjects.ToList()));
                }
            }
            result.Add(new ProjectIncludingDesignObjectResponce(project.Id, project.Cipher, project.Name, tree));
        }
        return result;
    }

    private static DesignObjectTreeResponce MapChilds(DesignObjectEntity parent, List<DesignObjectEntity> designObjects)
    {
        var childs = new List<DesignObjectTreeResponce>();
        foreach (var item in designObjects)
        {
            if (item.ParentDesignObjectId == parent.Id) 
            {
                childs.Add(MapChilds(item, designObjects));
            }
        }
        return new DesignObjectTreeResponce(parent.Id, parent.ParentDesignObjectId,parent.Code, childs);
    }
}
