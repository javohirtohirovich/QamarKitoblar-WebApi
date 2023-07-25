using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Interfaces.Users;
using QamarKitoblar.Service.Interafaces.Users;
using QamarKitoblar.DataAccess.Utils;

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
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
        => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));
    [HttpGet("count")]
    public async Task<IActionResult> CountAsync()
        => Ok(await _service.CountAsync());

    [HttpDelete("{UserId}")]
    public async Task<IActionResult> DeleteAsync(long UserId)
        => Ok(await _service.DeleteAsync(UserId));
}
