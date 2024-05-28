using Microsoft.AspNetCore.Mvc;
using ProjectManager.Contracts;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Models;
using ProjectManager.Domain.Abstractions;

namespace ProjectManager.Controllers;

[ApiController]
[Route("[controller]")]
public class DesignObjectsController : ControllerBase
{
    private readonly IDesignObjectsService _designObjectsService;

    public DesignObjectsController(IDesignObjectsService designObjectsService)
    {
        _designObjectsService = designObjectsService;
    }

    //[HttpGet]
    //public async Task<ActionResult<List<DesignObject>>> GetDesignProjects()
    //{
    //    var projects = await _projectsService.GetAllProjects();
    //    var responce = projects.Select(a => new Project(a.Id, a.Cipher, a.Name));
    //    return Ok(responce);
    //}
    [HttpPost]
    public async Task<ActionResult<int>> CreateDesignObject([FromBody] DesignObjectRequest request)
    {
        var designObject = new DesignObject(default(int), request.ProjectId, request.Code, request.Name);
        await _designObjectsService.CreateDesignObject(designObject);
        return Ok(designObject.Id);
    }
}
