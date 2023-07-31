using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Books;
using QamarKitoblar.Service.Dtos.BookComments;

namespace QamarKitoblar.Service.Interafaces.BookComments;

public interface IBookCommentService
{
    public Task<bool> CreateAsync(BookCommentCreateDto dto);
    public Task<bool> DeleteAsync(long CommentId);
    public Task<long> CountAsync(long bookId);
    public Task<bool> UpdateAsync(long CommentId, BookCommentUpdateDto dto);
    public Task<BookComent> GetByIdAsync(long CommentId);
    public Task<IList<BookComent>> GetAllAsync(long bookId, PaginationParams @params);
}
