using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;
using System.Xml.XPath;

namespace News.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ITokenService _tokenService;

    public UsersController(IUserService service, ITokenService tokenService)
    {
        _service = service;
        _tokenService = tokenService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken
        )
    {
        var user = await _service.GetByIdAsync(id, cancellationToken);
        
        return Ok(user);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] string id, 
        [FromBody] JsonPatchDocument<UserUpdateModel> user,
        CancellationToken cancellationToken
        )
    {
        var updatedUser = await _service.UpdateAsync(user, id, cancellationToken);

        return Ok(updatedUser);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(
        [FromQuery] Guid id,
        CancellationToken cancellationToken
        )
    {
        await _service.DeleteAsync(id, cancellationToken);

        return Ok();
    }
}