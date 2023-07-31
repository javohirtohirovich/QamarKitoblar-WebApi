using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Service.Dtos.Publishers;
using QamarKitoblar.Service.Interafaces.Publishers;
using QamarKitoblar.Service.Validators.Publishers;


namespace QamarKitoblar.WebApi.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _service;
    private readonly int MaxPageSize = 30;

    public PublisherController(IPublisherService publisherService)
    {
        this._service = publisherService;
    }

    //For Create
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAsync([FromForm] PublisherCreateDto dto)
    {
        var validator = new PublisherCreateValidator();
        var result = validator.Validate(dto);
        if (result.IsValid) return Ok(await _service.CreateAsync(dto));
        else return BadRequest(result.Errors);
    }

    //For Update
    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long publisherId, [FromForm] PublisherUpdateDto dto)
    {
        var validator = new PublisherUpdateValidator();
        var validationResult = validator.Validate(dto);
        if (validationResult.IsValid) return Ok(await _service.UpdateAsync(publisherId, dto));
        else return BadRequest(validationResult.Errors);
    }

    //For Delete
    [HttpDelete("{publisherId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long publisherId)
        => Ok(await _service.DeleteAsync(publisherId));

    //For Count
    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    //For GetById
    [HttpGet("{publisherId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByIdAsync(long publisherId)
        => Ok(await _service.GetByIdAsync(publisherId));

    //For GetAll
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));



}
