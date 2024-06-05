using ProjectManager.Domain.Contracts.DesignObject;

namespace ProjectManager.Application.Abstractions
{
    public interface IDesignObjectsService
    {
        Task<List<DesignObjectTreeResponce>> GetByProjectId(int projectId);

    }
}