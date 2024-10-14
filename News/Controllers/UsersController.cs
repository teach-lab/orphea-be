﻿using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<IActionResult> GetAsync([FromRoute] Guid id)
    {
        var user = await _service.GetAsync(id);
        if (user is null)
        {
            return NotFound($"User with ID {id} was not found.");
        }

        return Ok(user);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] JsonPatchDocument<UserUpdateModel> user)
    {
        if (user is null)
        {
            return BadRequest("Patch document cannot be null.");
        }

        var existingUser = await _service.GetAsync(Guid.Parse(id));
        if (existingUser is null)
        {
            return NotFound($"User with ID {id} was not found.");
        }

        var updatedUser = await _service.UpdateAsync(user, id);

        return Ok(updatedUser);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
    {
        var existingUser = await _service.GetAsync(id);
        if (existingUser is null)
        {
            return NotFound($"User with ID {id} was not found.");
        }

        await _service.DeleteAsync(id);

        return Ok();
    }
}