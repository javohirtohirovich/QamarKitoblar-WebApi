﻿using Dapper;
using QamarKitoblar.DataAccess.Interfaces.Books;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Books;
using QamarKitoblar.Domain.Entities.Geners;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Repositories.Books;

public class BookCommentRepository : BaseRepository, IBookCommentRepository
{
    public async Task<long> CountAsync(long bookId)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select Count(*) From book_comments Where book_id=@Id";
            var result = await _connection.QuerySingleAsync<long>(query, new {Id=bookId});
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

    public Task<long> CountAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<int> CreateAsync(BookComent entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.book_comments(book_id, user_id, comment, created_at, is_edited, updated_at) " +
                "VALUES (@BookId, @UserId, @Comment, @CreatedAt, @IsEdited, @UpdatedAt);";
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
            string query = "DELETE FROM public.book_comments WHERE id=@Id;";
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

    public async Task<IList<BookComent>> GetAllAsync(long bookId,PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM public.book_comments Where book_id=@Id Order By id Desc " +
                $"Offset {@params.GetSkipCount()} Limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<BookComent>(query, new {Id=bookId})).ToList();
            return result;

        }
        catch
        {
            return new List<BookComent>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    //-------------------------------------------------------------------------------------
    public Task<IList<BookComent>> GetAllAsync(PaginationParams @params)
    {
        throw new NotImplementedException();
    }
    //--------------------------------------------------------------------------------------

    public async Task<BookComent?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "Select * From book_comments Where id=@Id";
            var result = await _connection.QuerySingleAsync<BookComent>(query, new { Id = id });
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

    public async Task<int> UpdateAsync(long id, BookComent entity)
    {
        throw new NotImplementedException();
    }
}