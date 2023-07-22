using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Orders;

namespace QamarKitoblar.DataAccess.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, Order>, IGetAll<Order>
{
}
