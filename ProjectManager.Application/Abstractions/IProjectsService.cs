using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Abstractions
{
    public interface IProjectsService
    {
        Task<List<Project>> GetList();
        Task<ProjectDetailsDto> GetFullDataByClick(int id);
        Task<List<ProjectDetailsDto>> GerProjectsWithDesignObjects();
    }
}