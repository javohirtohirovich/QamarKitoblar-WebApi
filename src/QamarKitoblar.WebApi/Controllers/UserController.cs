using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Service.Dtos.Users;
using QamarKitoblar.Service.Interafaces.Users;

namespace QamarKitoblar.WebApi.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly int MaxPageSize = 30;

    public UserController(IUserService userService)
    {
        this._service = userService;
    }

    //For Get All

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));

    //For GetById

    [HttpGet("{UserId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetById(long UserId)
        => Ok(await _service.GetByIdAsync(UserId));

    //For Count

    [HttpGet("count")]
    [AllowAnonymous]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    //For Search

    [HttpGet("search/{search}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
    {
        var result = (await _service.SearchAsync(search, new PaginationParams(page, MaxPageSize)));
        return Ok(result.Item2);
    }

    //For Delete

    [HttpDelete("{UserId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(long UserId)
        => Ok(await _service.DeleteAsync(UserId));

    //For Update

    [HttpPut]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateAsync(long UserId, [FromForm] UserUpdateDto userUpdateDto)
        => Ok(await _service.UpdateAsync(UserId, userUpdateDto));
}
