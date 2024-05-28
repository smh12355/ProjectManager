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
    public async Task<ActionResult<List<Project>>> GetList()
    {
        var projects = await _projectsService.GetList();
        return Ok(projects);
    }
    [HttpGet("/JoinedEntities")]
    public async Task<ActionResult<ProjectDetailsDto>> GetFullDataByClick(int projectId)
    {
        var projectDesignObjects = await _projectsService.GetFullDataByClick(projectId);
        return Ok(projectDesignObjects);
    }
    [HttpGet("/smthing")]
    public async Task<ActionResult<List<ProjectDetailsDto>>> GetListWithDesignObjects()
    {
        var projectDesignObjects = await _projectsService.GerProjectsWithDesignObjects();
        return Ok(projectDesignObjects);
    }
}
