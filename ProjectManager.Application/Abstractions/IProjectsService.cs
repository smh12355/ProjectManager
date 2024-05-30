using ProjectManager.Domain.Contracts.Project;
using ProjectManager.Domain.Models;

namespace ProjectManager.Application.Abstractions
{
    public interface IProjectsService
    {
        Task<List<ProjectResponce>> GetList();
        Task<ProjectResponce> GetById(int id);
        Task<List<ProjectIncludingDesignObjectResponce>> GetListInludingDesignObjects();
        Task<ProjectDetailsDto> GetFullDataByClick(int id);
        Task<List<ProjectIncludeAllObjects>> GetListInludingAllEntities();
    }
}