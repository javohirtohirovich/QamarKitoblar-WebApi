using QamarKitoblar.DataAccess.Interfaces.Discounts;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Discounts;
using QamarKitoblar.Domain.Exceptions.Discounts;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Discounts;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Discounts;

namespace QamarKitoblar.Service.Services.Discounts;

public class DiscountService : IDiscountService
{
    private readonly IDiscountRepository _repository;
    private readonly IPaginator _paginator;

    public DiscountService(IDiscountRepository discountRepository, IPaginator paginator)
    {
        this._repository = discountRepository;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync()
    {
        var result = await _repository.CountAsync();
        return result;
    }

    public async Task<bool> CreateAsync(DiscountCreateDto dto)
    {
        Discount discount = new Discount()
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(discount);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long DiscountId)
    {
        var delResult = await _repository.GetByIdAsync(DiscountId);
        if (delResult is null) { throw new DiscountNotFoundException(); }
        var result = await _repository.DeleteAsync(DiscountId);
        return result > 0;
    }

    public async Task<IList<Discount>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<Discount> GetByIdAsync(long DiscountId)
    {
        var result = await _repository.GetByIdAsync(DiscountId);
        if (result == null) { throw new DiscountNotFoundException(); }
        else { return result; }
    }

    public async Task<bool> UpdateAsync(long DiscountId, DiscountUpdateDto dto)
    {
        var discount = await _repository.GetByIdAsync(DiscountId);
        if (discount is null) throw new DiscountNotFoundException();

        discount.Name = dto.Name;
        discount.Description = dto.Description;
        discount.UpdatedAt = TimeHelper.GetDateTime();
        var result = await _repository.UpdateAsync(DiscountId, discount);
        return result > 0;
    }
}
