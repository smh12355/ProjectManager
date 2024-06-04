using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.Project;
using ProjectManager.Filters;

namespace ProjectManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectsService _projectsService;

    public ProjectController(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponce>>> GetList()
    {
        return Ok(await _projectsService.GetList());
    }

    [HttpGet("{projectId}")]
    [ServiceFilter(typeof(ProjectNotFoundFilter))]
    public async Task<ActionResult<ProjectResponce>> GetById([FromRoute] int projectId)
    {
        return Ok(await _projectsService.GetById(projectId));
    }

    [HttpGet("IncludeDesignObjects")]
    public async Task<ActionResult<List<ProjectIncludingDesignObjectResponce>>> GetInludingDesignObjects()
    { 
        return Ok(await _projectsService.GetInludingDesignObjects());
    }

}
