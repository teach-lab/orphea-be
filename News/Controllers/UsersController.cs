using News.Services;
using News.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace News.Controllers;

[ApiController]
[Route("users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;

    public UsersController(IUserService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById([FromQuery] Guid id)
    {
        var user = await _service.GetUserById(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateModel user)
    {
        var createdUser = await _service.CreateUser(user);
        return Ok(createdUser);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] JsonPatchDocument<UserUpdateModel> user)
    {

        var updatedUser = await _service.UpdateUser(user, id);
        return Ok(updatedUser);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser([FromQuery] Guid id)
    {
        await _service.DeleteUser(id);
        return Ok();
    }
}