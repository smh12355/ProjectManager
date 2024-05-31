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
        var responce = await _dbContext.DesignObjects
            .AsNoTracking()
            .Where(a => a.ProjectId == projectId)
            .ToListAsync();
        foreach (var designObject in responce)
        {
            if (designObject.ParentDesignObjectId == null)
            {
                return MapChilds(designObject, responce);
            }
        }
        throw new NotImplementedException();
    }
    private static DesignObjectTreeResponce MapChilds(DesignObjectEntity parent, List<DesignObjectEntity> DesignObjects)
    {
        var Childs = new List<DesignObjectTreeResponce>();
        foreach (var item in DesignObjects)
        {
            if (item.ParentDesignObjectId == parent.Id)
            {
                Childs.Add(MapChilds(item, DesignObjects));
            }
        }
        return new DesignObjectTreeResponce(parent.Id, parent.ParentDesignObjectId, parent.Code, Childs);
    }
}
