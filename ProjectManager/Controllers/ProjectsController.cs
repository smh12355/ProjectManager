using Microsoft.AspNetCore.Mvc;
using ProjectManager.Contracts;
using ProjectManager.Domain.Abstractions;
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
    public async Task<ActionResult<List<Project>>> GetProjects()
    {
        var projects = await _projectsService.GetAllProjects();
        var responce = projects.Select(a => new Project(a.Id, a.Cipher, a.Name));
        return Ok(responce);
    }
    [HttpPost]
    public async Task<ActionResult<int>> CreateBook([FromBody] ProjectRequest request)
    {
        var project = new Project(default(int), request.Cipher, request.Name);
        await _projectsService.CreateProject(project);
        return Ok(project.Id);
    }
}
