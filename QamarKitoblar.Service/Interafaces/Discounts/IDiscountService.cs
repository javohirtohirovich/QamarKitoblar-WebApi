using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Discounts;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Service.Dtos.Categories;
using QamarKitoblar.Service.Dtos.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
