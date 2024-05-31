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

    [HttpGet("{ProjectId}")]
    public async Task<ActionResult<ProjectResponce>> GetById(int ProjectId)
    {
        var responce = await _projectsService.GetById(ProjectId);
        if (responce is null)
        {
            return NotFound(new { Message = $"Project with ID {ProjectId} was not found." });
        }
        return Ok(responce);
    }

    [HttpGet("IncludeDesignObjects")]
    public async Task<ActionResult<List<ProjectIncludingDesignObjectResponce>>> GetInludingDesignObjects()
    { 
        return Ok(await _projectsService.GetInludingDesignObjects());
    }

}
