namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Interns;
using WebApi.Services;

[ApiController]
[Route("api/v1/[controller]")]
public class InternsController : ControllerBase
{
    private IInternService _InternService;
    private IMapper _mapper;

    public InternsController(
        IInternService Internservice,
        IMapper mapper)
    {
        _InternService = Internservice;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var Interns = _InternService.GetAll();
        return Ok(Interns);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var Intern = _InternService.GetById(id);
        return Ok(Intern);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _InternService.Create(model);
        return Ok(new { message = "Intern created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _InternService.Update(id, model);
        return Ok(new { message = "Intern updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _InternService.Delete(id);
        return Ok(new { message = "Intern deleted" });
    }

    
}