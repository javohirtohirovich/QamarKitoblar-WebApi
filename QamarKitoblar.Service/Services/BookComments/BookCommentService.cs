using QamarKitoblar.DataAccess.Interfaces.Books;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Books;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Domain.Exceptions.Books;
using QamarKitoblar.Domain.Exceptions.Geners;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.BookComments;
using QamarKitoblar.Service.Interafaces.Auth;
using QamarKitoblar.Service.Interafaces.BookComments;
using QamarKitoblar.Service.Interafaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.BookComments;

public class BookCommentService : IBookCommentService
{
    private readonly IBookCommentRepository _repository;
    private readonly IPaginator _paginator;
    private readonly IIdentityService _identity;

    public BookCommentService(IBookCommentRepository commentRepository,IPaginator paginator,IIdentityService identity)
    {
        this._repository = commentRepository;
        this._paginator = paginator;
        this._identity = identity;
    }
    public Task<long> CountAsync(long bookId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> CreateAsync(BookCommentCreateDto dto)
    {
        BookComent bookComent = new BookComent()
        {
            BookId = dto.BookId,
            UserId = _identity.UserId,
            Comment = dto.Comment,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
            IsEdited = false

        };
        var result = await _repository.CreateAsync(bookComent);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long CommentId)
    {
        var resultDel = await _repository.GetByIdAsync(CommentId);
        if (resultDel is null) { throw new BookCommentNotFoundException(); }
        var result = await _repository.DeleteAsync(CommentId);
        return result > 0;
    }

    public async Task<IList<BookComent>> GetAllAsync(long bookId, PaginationParams @params)
    {
        var result=await _repository.GetAllAsync(bookId, @params);
        var count = await _repository.CountAsync(bookId);
        _paginator.Paginate(count, @params);
        return result;
    }

    public Task<BookComent> GetByIdAsync(long CommentId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(long CommentId, BookCommentUpdateDto dto)
    {
        throw new NotImplementedException();
    }
}
