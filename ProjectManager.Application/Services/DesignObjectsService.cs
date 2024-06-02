using Microsoft.EntityFrameworkCore;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.Services;

public class DesignObjectsService : IDesignObjectsService
{
    private readonly IProjectManagerDbContext _dbContext;
    public DesignObjectsService(IProjectManagerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DesignObjectTreeResponce> GetByProjectId(int projectId)
    {
        var result = await _dbContext.DesignObjects
            .AsNoTracking()
            .Where(a => a.ProjectId == projectId)
            .ToListAsync();
        foreach (var designObject in result)
        {
            if (designObject.ParentDesignObjectId == null)
            {
                return MapChilds(designObject, result);
            }
        }
        throw new NotImplementedException();
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
        return new DesignObjectTreeResponce(parent.Id, parent.ParentDesignObjectId, parent.Code, childs);
    }
}
