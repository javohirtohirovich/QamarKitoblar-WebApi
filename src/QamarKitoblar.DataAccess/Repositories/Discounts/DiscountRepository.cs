using QamarKitoblar.DataAccess.Interfaces.Discounts;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Discounts;

namespace QamarKitoblar.DataAccess.Repositories.Discounts;

public class DiscountRepository : BaseRepository, IDiscountRepository
{
    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public Task<int> CreateAsync(Discount entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IList<Discount>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public Task<Discount> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<int> UpdateAsync(long id, Discount entity)
    {
        throw new NotImplementedException();
    }
}
