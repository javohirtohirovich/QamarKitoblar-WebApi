using Dapper;
using QamarKitoblar.DataAccess.Interfaces.Orders;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Orders;

namespace QamarKitoblar.DataAccess.Repositories.Orders
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public async Task<long> CountAsync()
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select Count(*) From orders";
                var result = await _connection.QuerySingleAsync<long>(query);
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }


        public async Task<int> CreateAsync(Order entity)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.orders(user_id, status, book_price, delivery_price, result_price, " +
                    "latitude, longitude, payment_type, is_paid, is_contracted, description, created_at, updated_at) " +
                    "VALUES (@UserId, @Status, @BookPrice, @DeliveryPrice, @ResultPrice, @Latitude, @Longitude, @PaymentType, " +
                    "@IsPaid, @IsContracted, @Description, @CreatedAt, @UpdatedAt);";
                var result = await _connection.ExecuteAsync(query, entity);
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> DeleteAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Delete From orders Where id=@Id;";
                var result = await _connection.ExecuteAsync(query, new { Id = id });
                return result;
            }
            catch
            {
                return 0;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<IList<Order>> GetAllAsync(PaginationParams @params)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "SELECT * FROM public.orders Order By id Desc " +
                    $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";
                var result=(await _connection.QueryAsync<Order>(query)).ToList();
                return result;

            }
            catch
            {
                return new List<Order>();
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<Order?> GetByIdAsync(long id)
        {
            try
            {
                await _connection.OpenAsync();
                string query = "Select * From Where id=@Id";
                var result = await _connection.QuerySingleAsync<Order>(query, new {Id=id});
                return result;
            }
            catch
            {
                return null;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> UpdateAsync(long id, Order entity)
        {
            try 
            {
                await _connection.CloseAsync();
                string query = "UPDATE public.orders SET " +
                    "id=@Id, user_id=@UserId, status=@Status, book_price=@BookPrice, delivery_price=@DeliveryPrice, result_price=@ResultPrice, " +
                    "latitude=@Latitude, longitude=@Longitude, payment_type=@PaymentType, is_paid=@IsPaid, is_contracted=@IsContracted, " +
                    "description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt" +
                    $"WHERE id={id};";
                var result = await _connection.ExecuteAsync(query, entity);
                return result;
            }
            catch
            {
                return 0; 
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }
    }
}
