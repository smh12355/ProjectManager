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
	public async Task<ActionResult<List<DesignObjectTreeResponce>>> GetByProjectId([FromRoute]int projectId)
	{
        var responce = await _designObjectsService.GetByProjectId(projectId);
        return Ok(responce);
	}
}
