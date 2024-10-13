using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using News.Entities.Models.ModelsUpdate;
using News.Services.ServicesInterface;

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
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var user = await _service.GetAsync(id);

        return Ok(user);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] JsonPatchDocument<UserUpdateModel> user)
    {
        var updatedUser = await _service.UpdateAsync(user, id);

        return Ok(updatedUser);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
    {
        await _service.DeleteAsync(id);

        return Ok();
    }
}