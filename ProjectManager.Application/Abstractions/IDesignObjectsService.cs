using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Abstractions;

public interface IDesignObjectsService
{
    Task<int> CreateDesignObject(DesignObject desighObject);
    Task<int> DeleteDesignObject(int id);
    Task<List<DesignObject>> GetAllDesignObjects();
    Task<int> UpdateDesignObject(int id, int projectId, string code, string name);
}