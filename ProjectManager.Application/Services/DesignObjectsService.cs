using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;
using ProjectManager.Infrastructure.Repository;

namespace ProjectManager.Application.Services;

public class DesignObjectsService : IDesignObjectsService
{
    private readonly IDesignObjectsRepository _designObjectsRepository;

    public DesignObjectsService(IDesignObjectsRepository designObjectsRepository)
    {
        _designObjectsRepository = designObjectsRepository;
    }

    public async Task<List<DesignObject>> GetAllDesignObjects()
    {
        return await _designObjectsRepository.Get();
    }

    public async Task<int> CreateDesignObject(DesignObject desighObject)
    {
        return await _designObjectsRepository.Create(desighObject);
    }

    public async Task<int> UpdateDesignObject(int id, int projectId, string code, string name)
    {
        return await _designObjectsRepository.Update(id, projectId, code, name);
    }

    public async Task<int> DeleteDesignObject(int id)
    {
        return await _designObjectsRepository.Delete(id);
    }
}
