using ProjectManager.Domain.Models;

namespace ProjectManager.Domain.Abstractions;   

public interface IProjectsService
{
    Task<int> CreateProject(Project project);
    Task<int> DeleteProject(int id);
    Task<List<Project>> GetAllProjects();
    Task<int> UpdateProject(int id, string cipher, string name);
}