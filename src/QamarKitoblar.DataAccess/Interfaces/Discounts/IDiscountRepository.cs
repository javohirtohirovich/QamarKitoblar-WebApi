using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Discounts;

namespace QamarKitoblar.DataAccess.Interfaces.Discounts
{
    public interface IDiscountRepository : IRepository<Discount, Discount>, IGetAll<Discount>
    {
    }
}
