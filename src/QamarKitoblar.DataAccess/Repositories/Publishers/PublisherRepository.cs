using Dapper;
using QamarKitoblar.DataAccess.Interfaces.Publishers;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Publishers;

namespace QamarKitoblar.DataAccess.Repositories.Publishers;

public class PublisherRepository : BaseRepository, IPublisherRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(id) From publishers";
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

    public async Task<int> CreateAsync(Publisher entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.publishers(name, description, image_path, phone_number, created_at, updated_at) " +
                "VALUES (@Name, @Description, @ImagePath, @PhoneNumber, @CreatedAt, @UpdatedAt);";
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
            string query = "Delete From publishers Where id=@Id";
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

    public async Task<IList<Publisher>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM public.publishers Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Publisher>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Publisher>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Publisher?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From publishers Where id=@Id";
            var result = await _connection.QuerySingleAsync<Publisher>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Publisher entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.publishers " +
                "SET name=@Name, description=@Description, image_path=@ImagePath, phone_number=@PhoneNumber, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id={id};";
            var result = await _connection.ExecuteAsync(query,entity);
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
