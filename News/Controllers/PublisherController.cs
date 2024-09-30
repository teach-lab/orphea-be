﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using News.Entities.Models;
using News.Services.ServicesInterface;

namespace News.Controllers;

[ApiController]
[Route("publisher")]
public class PublisherController : Controller
{        
    private readonly IPublisherService _service;

    public PublisherController(IPublisherService service)
    {            
        _service = service;
    }

    [HttpGet]
    public IActionResult GetCompanyById([FromQuery] Guid id)
    {
        var result = _service.GetById(id);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateCompany([FromBody] PublisherModel model)
    {
        _service.Add(model);            

        return Created();
    }

    [HttpPut]
    public IActionResult UpdateCompany([FromBody] PublisherModel model)
    {
        _service.Update(model);

        return Accepted();
    }

    [HttpDelete]
    public IActionResult DeleteCompanyById(Guid id)
    {
        var result = _service.GetById(id);

        if (result is not null)
        {
            _service.Remove(id);
        }
        return NoContent();
    }
}
