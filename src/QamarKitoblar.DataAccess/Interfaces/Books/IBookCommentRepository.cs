using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Books;

namespace QamarKitoblar.DataAccess.Interfaces.Books;

public interface IBookCommentRepository : IRepository<BookComent, BookComent>, IGetAll<BookComent>
{
    public Task<IList<BookComent>> GetAllAsync(long bookId, PaginationParams @params);
    public Task<long> CountAsync(long bookId);
    public Task<IList<BookComent>> GetAllUserIdAsync(long bookId,long userId,PaginationParams @params);
}
