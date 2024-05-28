using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Abstractions
{
    public interface IDesignObjectsService
    {
        Task<List<DesignObject>> GetByProjectId(int projectId);
    }
}