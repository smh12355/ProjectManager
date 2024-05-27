using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Abstractions
{
    public interface IProjectsRepository
    {
        Task<int> Create(Project project);
        Task<int> Delete(int id);
        Task<List<Project>> Get();
        Task<int> Update(int id, string cipher, string name);
    }
}