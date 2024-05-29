using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Abstractions
{
    public interface IDesignObjectsService
    {
        Task<List<DesignObjectResponce>> GetByProjectId(int projectId);
    }
}