using QamarKitoblar.DataAccess.Interfaces.Orders;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Orders;

namespace QamarKitoblar.DataAccess.Repositories.Orders
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Order>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
