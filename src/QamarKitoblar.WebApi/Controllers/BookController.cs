using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.Service.Interafaces.Books;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Service.Dtos.Books;
using Microsoft.AspNetCore.Authorization;
using QamarKitoblar.Service.Validators.Geners;
using QamarKitoblar.Service.Validators.Books;
using FluentValidation;

namespace QamarKitoblar.WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly int MaxPageSize = 30;
        public BookController(IBookService bookService) 
        {
            this._service=bookService;
        }

        //For GetAll

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));

        //For GetById

        [HttpGet("{bookId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(long bookId)
            =>Ok(await _service.GetByIdAsync(bookId));

        //For Search

        [HttpGet("search/{search}")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchAsync(string search, [FromQuery] int page = 1)
        { 
            var result =(await _service.SearchAsync(search, new PaginationParams(page, MaxPageSize)));
            return Ok(result.Item2);
        
        }

        //For Count

        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            =>Ok(await _service.CountAsync());

        //For Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] BookCreateDto dto)
        {
            var bookValidator = new BookCreateValidator();
            var result = bookValidator.Validate(dto);
            if (result.IsValid) return Ok(await _service.CreateAsync(dto));
            else return BadRequest(result.Errors);
        }

        //For Delete

        [HttpDelete("{BookId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long BookId)
            =>Ok(await _service.DeleteAsync(BookId));

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] BookUpdateDto dto)
        {
            var updateValidator = new BookUpdateValidator();
            var validationResult = updateValidator.Validate(dto);
            if (validationResult.IsValid) return Ok(await _service.UpdateAsync(id, dto));
            else return BadRequest(validationResult.Errors);
        }

    }
}
