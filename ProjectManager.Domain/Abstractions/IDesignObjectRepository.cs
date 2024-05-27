using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Abstractions
{
    public interface IDesignObjectRepository
    {
        Task<int> Create(DesignObject designObject);
        Task<int> Delete(int id);
        Task<List<DesignObject>> Get();
        Task<int> Update(int id, int projectId, string code, string name);
    }
}