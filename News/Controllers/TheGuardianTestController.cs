using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using News.Entities.Models;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("source-news")]
public class TheGuardianTestController : ControllerBase
{
    private readonly ITheGuardianService _apiService;
    private readonly SourceNewsApiConfigModel _config;

    public TheGuardianTestController(ITheGuardianService apiService, IOptions<SourceNewsApiConfigModel> config)
    {
        _apiService = apiService;
        _config = config.Value;
    }

    [HttpGet("the-guardian")]
    public async Task<IActionResult> GetNews()
    {
        var api = _config.TheGuardian;
        string apiUrl = $"https://content.guardianapis.com/search?api-key={api}";
        var data = await _apiService.GetDataAsync(apiUrl);
        return Ok(data);
    }
}