using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Discounts;
using QamarKitoblar.Service.Dtos.Discounts;

namespace QamarKitoblar.Service.Interafaces.Discounts;

public interface IDiscountService
{
    public Task<bool> CreateAsync(DiscountCreateDto dto);
    public Task<bool> DeleteAsync(long DiscountId);
    public Task<long> CountAsync();
    public Task<bool> UpdateAsync(long DiscountId, DiscountUpdateDto dto);
    public Task<Discount> GetByIdAsync(long DiscountId);
    public Task<IList<Discount>> GetAllAsync(PaginationParams @params);
}
