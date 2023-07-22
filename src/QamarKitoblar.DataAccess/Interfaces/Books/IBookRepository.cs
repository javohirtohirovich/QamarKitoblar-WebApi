using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.DataAccess.ViewModels.BooksVM;
using QamarKitoblar.Domain.Entities.Books;

namespace QamarKitoblar.DataAccess.Interfaces.Books
{
    public interface IBookRepository : IRepository<Book, BookViewModel>, IGetAll<BookViewModel>, ISearchable<BookViewModel>
    {
    }
}
