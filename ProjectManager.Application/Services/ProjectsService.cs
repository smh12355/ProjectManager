using ProjectManager.Domain.Abstractions;
using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Services;

public class ProjectsService
{
    private readonly IProjectsRepository _projectRepository;

    public ProjectsService(IProjectsRepository projectsRepository)
    {
        _projectRepository = projectsRepository;
    }

    public async Task<List<Project>> GetAllProjects()
    {
        return await _projectRepository.Get();
    }

    public async Task<int> CreateProject(Project project)
    {
        return await _projectRepository.Create(project);
    }

    public async Task<int> UpdateProject(int id, string cipher, string name)
    {
        return await _projectRepository.Update(id, cipher, name);
    }

    public async Task<int> DeleteProject(int id)
    {
        return await _projectRepository.Delete(id);
    }
}
