using Microsoft.AspNetCore.Mvc;
using ProjectManager.Application.Abstractions;
using ProjectManager.Application.Services;
using ProjectManager.Domain.Contracts.DocSet;

namespace ProjectManager.Controllers;

[ApiController]
[Route("api/Project/DesignObject/[controller]")]
public class DosSetController : ControllerBase
{
    private readonly IDocSetService _docSetService;

    public DosSetController(IDocSetService docSetService)
    {
        _docSetService = docSetService;
    }

    [HttpGet("ByProject")]
    public async Task<ActionResult<List<DocSetByProjectResponce>>> GetByProject(int ProjectId)
    {
        return Ok(await _docSetService.GetByProject(ProjectId));
    }
    [HttpGet("ByDesignObject")]
    public async Task<ActionResult<List<DocSetByProjectResponce>>> GetByDesignObject(int DesignObjectId)
    {
        return Ok(await _docSetService.GetByDesignObject(DesignObjectId));
    }
}
