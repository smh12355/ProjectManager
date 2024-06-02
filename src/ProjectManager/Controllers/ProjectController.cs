using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.Project;

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
    public async Task<ActionResult<ProjectResponce>> GetById([FromRoute] int projectId)
    {
        var responce = await _projectsService.GetById(projectId);
        if (responce is null)
        {
            return NotFound(new { Message = $"Project with ID {projectId} was not found." });
        }
        return Ok(responce);
    }

    [HttpGet("IncludeDesignObjects")]
    public async Task<ActionResult<List<ProjectIncludingDesignObjectResponce>>> GetInludingDesignObjects()
    { 
        return Ok(await _projectsService.GetInludingDesignObjects());
    }

}
