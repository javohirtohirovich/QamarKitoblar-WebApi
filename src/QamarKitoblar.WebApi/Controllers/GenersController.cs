using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Exceptions.Geners;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Interafaces.Geners;
using QamarKitoblar.Service.Validators.Geners;

namespace QamarKitoblar.WebApi.Controllers;

[Route("api/geners")]
[ApiController]
public class GenersController : ControllerBase
{
    private readonly IGenerService _service;
    private readonly int MaxPageSize=30;
    public GenersController(IGenerService generService)
    {
        this._service = generService;
    }
    //For Create
    
    [HttpPost]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] GenerCreateDto dto)
    {
        var generValidator = new GenerCreateValidator();
        var result = generValidator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    //For Delete
    
    [HttpDelete("{generId}")]
    [Authorize(Roles ="Admin")]
    public async Task<IActionResult> DeleteAsync(long generId)
    {
        var result = await _service.DeleteAsync(generId);
        if (result) { return Ok(); }
        else { throw new GenerNotFoundException(); }
    }

    //For Count
    
    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    //For Update

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long id, [FromForm] GenerUpdateDto dto)
    {
        var updateValidator = new GenerUpdateValidator();
        var validationResult = updateValidator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(id, dto));
        else return BadRequest(validationResult.Errors);
    }   
    
    //For GetById
    
    [HttpGet("{generId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long generId)
        => Ok(await _service.GetByIdAsync(generId));

    
    //For GetAll

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize) ));
}