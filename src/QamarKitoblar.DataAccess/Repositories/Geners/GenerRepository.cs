using Dapper;
using QamarKitoblar.DataAccess.Interfaces.Geners;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Geners;

namespace QamarKitoblar.DataAccess.Repositories.Geners;

public class GenerRepository : BaseRepository, IGenerRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From geners";
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

    public async Task<int> CreateAsync(Gener entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.geners(name, description, created_at, updated_at)" +
                "VALUES (@Name, @Description, @CreatedAt, @UpdatedAt);";
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
            string query = "DELETE FROM public.geners WHERE id=@Id;";
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

    public async Task<IList<Gener>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM public.geners Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Gener>(query)).ToList();
            return result;

        }
        catch
        {
            return new List<Gener>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Gener?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From geners Where id=@Id";
            var result = await _connection.QuerySingleAsync<Gener>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, Gener entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE public.geners " +
                "SET name=@Name, description=@Description, created_at=@CreatedAt, updated_at=@UpdatedAt " +
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
