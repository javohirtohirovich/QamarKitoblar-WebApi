using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Service.Dtos.Publishers;
using QamarKitoblar.Service.Interafaces.Publishers;
using System.Runtime.InteropServices;


namespace QamarKitoblar.WebApi.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _service;
    private readonly int MaxPageSize = 30;

    public PublisherController(IPublisherService publisherService)
    {
         this._service=publisherService;
    }

    //For Create
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] PublisherCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

    //For Update
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(long publisherId,[FromForm] PublisherUpdateDto dto)
        => Ok(await _service.UpdateAsync(publisherId,dto));

    //For Delete
    [HttpDelete("{publisherId}")]
    public async Task<IActionResult> DeleteAsync(long publisherId)
        => Ok(await _service.DeleteAsync(publisherId));

    //For Count
    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    //For GetById
    [HttpGet("{publisherId}")]
    public async Task<IActionResult> GetByIdAsync(long publisherId)
        => Ok(await _service.GetByIdAsync(publisherId));

    //For GetAll
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));



}
