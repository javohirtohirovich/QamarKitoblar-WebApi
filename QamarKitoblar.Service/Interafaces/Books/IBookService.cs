using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.BooksVM;
using QamarKitoblar.DataAccess.ViewModels.UsersVM;
using QamarKitoblar.Domain.Entities.Books;
using QamarKitoblar.Domain.Entities.Geners;
using QamarKitoblar.Service.Dtos.Books;
using QamarKitoblar.Service.Dtos.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Interafaces.Books;

public interface IBookService
{
    public Task<bool> CreateAsync(BookCreateDto dto);
    public Task<bool> DeleteAsync(long BookId);
    public Task<long> CountAsync();
    public Task<bool> UpdateAsync(long BookId, BookUpdateDto dto);
    public Task<BookViewModel> GetByIdAsync(long BookId);
    public Task<IList<BookViewModel>> GetAllAsync(PaginationParams @params);

    public Task<(long ItemsCount, IList<BookViewModel>)> SearchAsync(string search, PaginationParams @params);
}
