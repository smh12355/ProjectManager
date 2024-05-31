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

    [HttpGet]
    public async Task<ActionResult<List<DocSetByProjectResponce>>> Get()
    {
        return Ok(await _docSetService.Get());
    }
}
