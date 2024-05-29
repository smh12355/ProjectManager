using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.Project;
using ProjectManager.Domain.Models;

namespace ProjectManager.Controllers;
[ApiController]
[Route("api")]
public class ProjectController : ControllerBase
{
    private readonly IProjectsService _projectsService;

    public ProjectController(IProjectsService projectsService)
    {
        _projectsService = projectsService;
    }

    [HttpGet("ProjectsList")]
    public async Task<ActionResult<List<ProjectResponce>>> GetList() =>
        Ok(await _projectsService.GetList());

    [HttpGet("Project/{ProjectId}")]
    public async Task<ActionResult<ProjectResponce>> GetById(int ProjectId)
    {
        var responce = await _projectsService.GetById(ProjectId);
        if (responce is null)
        {
            return NotFound(new { Message = $"Project with ID {ProjectId} was not found." });
        }
        return Ok(responce);
    }

    [HttpGet("ProjectsListInludingDesignObjects")]
    public async Task<ActionResult<List<ProjectIncludingDesignObjectResponce>>> GetListInludingDesignObjects() =>
        Ok(await _projectsService.GetListInludingDesignObjects());

    [HttpGet("/JoinedEntities")]
    public async Task<ActionResult<ProjectDetailsDto>> GetFullDataByClick(int projectId)
    {
        var projectDesignObjects = await _projectsService.GetFullDataByClick(projectId);
        return Ok(projectDesignObjects);
    }
}
