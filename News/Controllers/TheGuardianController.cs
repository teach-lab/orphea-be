using Microsoft.AspNetCore.Mvc;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("the-guardian")]
public class TheGuardianController : ControllerBase
{
    private readonly ITheGuardianService _apiService;

    public TheGuardianController(ITheGuardianService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet("all-articles")]
    public async Task<IActionResult> GetAllArticlesAsync()
    {
        var data = await _apiService.GetAllArticlesAsync();
        return Ok(data);
    }

    [HttpGet("single-article")]
    public async Task<IActionResult> GetSignleAsync([FromQuery] string id)
    {
        var data = await _apiService.GetSignleAsync(id);
        return Ok(data);
    }
}