using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Service.Dtos.BookComments;
using QamarKitoblar.Service.Interafaces.BookComments;

namespace QamarKitoblar.WebApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class BookCommentController : ControllerBase
    {
        private readonly IBookCommentService _service;
        private readonly int MaxPageSize = 30;
        public BookCommentController(IBookCommentService commentService)
        {
            this._service = commentService;
        }
        //For Create
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync([FromForm] BookCommentCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

        //For Delete
        [HttpDelete("{commentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long commentId)
            => Ok(await _service.DeleteAsync(commentId));

        //For GetAll
        [HttpGet("getall")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] long bookId, [FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(bookId, new PaginationParams(page, MaxPageSize)));



    }
}
