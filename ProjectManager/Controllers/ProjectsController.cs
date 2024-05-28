using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Contracts;
using ProjectManager.Domain.Models;

namespace ProjectManager.Controllers;
[ApiController]
[Route("[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectsService _projectsService;

    public ProjectsController(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Project>>> GetAllProjects()
    {
        var projects = await _projectsService.GetAllProjects();
        return Ok(projects);
    }
    [HttpGet("{projectId}/DesignObjects")]
    public async Task<ActionResult<List<DesignObject>>> GetDesignObjectsByProjectId(int projectId)
    {
        var projectDesignObjects = await _projectsService.GetDesignObjectsByProjectId(projectId);
        return Ok(projectDesignObjects);
    }
    [HttpGet("/JoinedEntities")]
    public async Task<ActionResult<List<ProjectDetailsDto>>> GetFullDataByClick(int projectId)
    {
        var projectDesignObjects = await _projectsService.GetFullDataByClick(projectId);
        return Ok(projectDesignObjects);
    }
}
