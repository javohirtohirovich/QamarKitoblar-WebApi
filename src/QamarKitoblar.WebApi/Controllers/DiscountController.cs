using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Exceptions.Discounts;
using QamarKitoblar.Domain.Exceptions.Geners;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Dtos.Discounts;
using QamarKitoblar.Service.Interafaces.Discounts;
using System.Data;

namespace QamarKitoblar.WebApi.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly int MaxPageSize = 30;

        public DiscountController(IDiscountService discountService) 
        {
            this._service = discountService;
        }

        //For Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] DiscountCreateDto dto)
        => Ok(await _service.CreateAsync(dto));

        //For Delete
        [HttpDelete("{discountId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(long discountId)
        {
            var result = await _service.DeleteAsync(discountId);
            if (result) { return Ok(); }
            else { throw new DiscountNotFoundException(); }
        }

        //For Count
        [HttpGet("count")]
        [AllowAnonymous]
        public async Task<IActionResult> CountAsync()
            => Ok(await _service.CountAsync());

        //For Update
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAsync(long id, [FromForm] DiscountUpdateDto dto)
            => Ok(await _service.UpdateAsync(id, dto));
        
        //For GetById
        [HttpGet("{discountId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByIdAsync(long discountId)
            => Ok(await _service.GetByIdAsync(discountId));

        //For GetAll
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, MaxPageSize)));

    }
}
