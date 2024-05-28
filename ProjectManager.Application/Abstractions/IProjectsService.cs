using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Abstractions
{
    public interface IProjectsService
    {
        Task<List<Project>> GetAllProjects();
        Task<List<DesignObject>> GetDesignObjectsByProjectId(int projectId);
        Task<List<ProjectDetailsDto>> GetFullDataByClick(int id);
    }
}