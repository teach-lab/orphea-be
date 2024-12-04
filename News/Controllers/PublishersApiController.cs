using Microsoft.AspNetCore.Mvc;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("publishers")]
public class PublishersApiController : ControllerBase
{
    private readonly ITheGuardianService _apiService;

    public PublishersApiController(ITheGuardianService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("articles")]
    public async Task<IActionResult> GetAllArticlesAsync(CancellationToken cancellationToken)
    {
        var data = await _apiService.GetAllAsync(cancellationToken);
        return Ok(data);
    }

    [HttpGet("articles/{id}")]
    public async Task<IActionResult> GetSignleAsync(
        [FromRoute] string id,
        CancellationToken cancellationToken)
    {
        var data = await _apiService.GetAsync(id, cancellationToken);
        return Ok(data);
    }
}