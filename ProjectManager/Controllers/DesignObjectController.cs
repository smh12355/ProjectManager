using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Contracts.DesignObject;
using ProjectManager.Domain.Models;

namespace ProjectManager.Controllers;

[ApiController]
[Route("api")]
public class DesignObjectController : ControllerBase
{
    private readonly IDesignObjectsService _designObjectsService;

    public DesignObjectController(IDesignObjectsService designObjectsService)
	{
		_designObjectsService = designObjectsService;
	}
	[HttpGet("DesignObjects/{projectId}")]
	public async Task<ActionResult<List<DesignObjectResponce>>> GetByProjectId(int projectId) =>
		await _designObjectsService.GetByProjectId(projectId);
}
