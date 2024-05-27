using ProjectManager.Domain.Models.Projects;

namespace ProjectManager.Domain.Abstractions;

public interface IProjectService
{
    Task<GetProjectsResponse> Get(GetProjectsRequest request);
}
