using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Models;

namespace ProjectManager.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DesignObjectController : ControllerBase
{
    private readonly IDesignObjectsService _designObjectsService;

    public DesignObjectController(IDesignObjectsService designObjectsService)
	{
		_designObjectsService = designObjectsService;
	}
	[HttpGet("{projectId}")]
	public async Task<ActionResult<List<DesignObject>>> GetByProjectId(int projectId)
	{
        return await _designObjectsService.GetByProjectId(projectId);
	}
}
