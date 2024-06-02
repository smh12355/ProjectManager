using ProjectManager.Domain.Contracts.Project;

namespace ProjectManager.Application.Abstractions
{
    public interface IProjectsService
    {
        Task<List<ProjectResponce>> GetList();
        Task<ProjectResponce> GetById(int id);
        Task<List<ProjectIncludingDesignObjectResponce>> GetInludingDesignObjects();
    }
}