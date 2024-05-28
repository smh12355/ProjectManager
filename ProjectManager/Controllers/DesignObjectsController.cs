using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Domain.Models;

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
	[HttpGet]
	public async Task<ActionResult<List<DesignObject>>> GetByProjectId(int projectId)
	{
        return await _designObjectsService.GetByProjectId(projectId);
	}
}
