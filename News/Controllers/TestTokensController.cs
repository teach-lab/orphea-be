using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace News.Controllers;

[ApiController]
[Route("test-tokens")]
public class TestTokensController : ControllerBase
{
    [HttpGet("public")]
    public async Task<IActionResult> PublicGet()
    {
        return Ok();
    }

    [HttpGet("private")]
    [Authorize]
    public async Task<IActionResult> PrivateGet()
    {
        return Ok();
    }
}