using ProjectManager.Domain.Contracts.DesignObject;

namespace ProjectManager.Application.Abstractions
{
    public interface IDesignObjectsService
    {
        Task<DesignObjectTreeResponce> GetByProjectId(int projectId);

    }
}