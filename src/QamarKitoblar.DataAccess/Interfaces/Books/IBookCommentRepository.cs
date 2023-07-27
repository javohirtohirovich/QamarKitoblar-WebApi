using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Interfaces.Books;

public interface IBookCommentRepository : IRepository<BookComent,BookComent>,IGetAll<BookComent>
{
    public  Task<IList<BookComent>> GetAllAsync(long bookId,PaginationParams @params);
    public Task<long> CountAsync(long bookId);
}
