using Microsoft.AspNetCore.Mvc;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("api/open-ai")]
public class OpenAiTestController : ControllerBase
{
    private readonly IAiIntegrationService _aiIntegrationService;

    public OpenAiTestController(IAiIntegrationService aiIntegrationService)
    {
        _aiIntegrationService = aiIntegrationService;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateText([FromBody] string userContent)
    {
        var requestModel = _aiIntegrationService.CreateRequestModel(userContent);
        var result = await _aiIntegrationService.GenerateText(requestModel);

        return Ok(result);
    }
}