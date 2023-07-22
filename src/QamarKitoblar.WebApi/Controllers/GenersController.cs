using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Exceptions.Geners;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Interafaces.Geners;

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
    public async Task<IActionResult> CreateAsync([FromForm] GenerCreateDto dto)
    => Ok(await _service.CreateAsync(dto));

    //For Delete
    [HttpDelete("{generId}")]
    public async Task<IActionResult> DeleteAsync(long generId)
    {
        var result = await _service.DeleteAsync(generId);
        if (result) { return Ok(); }
        else { throw new GenerNotFoundException(); }
    }

    //For Count
    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    //For Update
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(long id, [FromForm] GenerUpdateDto dto)
        => Ok(await _service.UpdateAsync(id, dto));
    //For GetById
    [HttpGet("{generId}")]
    public async Task<IActionResult> GetByIdAsync(long generId)
        => Ok(await _service.GetByIdAsync(generId));

    //For GetAll
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize) ));
}