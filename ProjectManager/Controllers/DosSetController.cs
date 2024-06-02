using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Contracts.DocSet;

namespace ProjectManager.Controllers;

[ApiController]
[Route("/api/Project")]
public class DosSetController : ControllerBase
{
    private readonly IDocSetService _docSetService;

    public DosSetController(IDocSetService docSetService)
    {
        _docSetService = docSetService;
    }

    [HttpGet("{projectId}/DesignObject/[controller]/GetByProject")]
    public async Task<ActionResult<List<DocSetByProjectResponce>>> GetByProject([FromRoute] int projectId)
    {
        return Ok(await _docSetService.GetByProject(projectId));
    }
    [HttpGet("DesignObject/{designObjectId}/[controller]/GetByDesignObject")]
    public async Task<ActionResult<List<DocSetByProjectResponce>>> GetByDesignObject([FromRoute] int designObjectId)
    {
        return Ok(await _docSetService.GetByDesignObject(designObjectId));
    }
}
