using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.DataAccess.Repositories.Geners;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Domain.Exceptions.Geners;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Interafaces.Geners;

namespace QamarKitoblar.WebApi.Controllers;

[Route("api/geners")]
[ApiController]
public class GenersController : ControllerBase
{
    private readonly IGenerService _service;

    public GenersController(IGenerService generService)
    {
        this._service = generService;
    }
    //For Create
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] GenerCreateDto dto)
    => Ok(await _service.CreateAsync(dto));

    //For Delete
    [HttpDelete]
    public async Task<IActionResult> DeleteAsync([FromForm] long GenerId)
    {
        var result = await _service.DeleteAsync(GenerId);
        if (result) { return Ok(); }
        else { throw new GenerNotFoundException(); }
    }

    //ForCount
    [HttpGet]
    public async Task<IActionResult> CountAsync()
        =>Ok(await _service.CountAsync());
}