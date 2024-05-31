using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Contracts.DesignObject;

namespace ProjectManager.Controllers;

[ApiController]
[Route("api/Project/{projectId}/[controller]")]
public class DesignObjectController : ControllerBase
{
    private readonly IDesignObjectsService _designObjectsService;
    private readonly IProjectsService _projectsService;

    public DesignObjectController(IDesignObjectsService designObjectsService, IProjectsService projectsService)
	{
		_designObjectsService = designObjectsService;
        _projectsService = projectsService;

    }
	[HttpGet()]
	public async Task<ActionResult<DesignObjectTreeResponce>> GetByProjectId([FromRoute]int projectId)
	{
        var responce = await _projectsService.GetById(projectId);
        if (responce is null)
        {
            return NotFound(new { Message = $"Project with ID {projectId} was not found." });
        }
        return await _designObjectsService.GetByProjectId(projectId);
	}
}
