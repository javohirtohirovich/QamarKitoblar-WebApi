using QamarKitoblar.DataAccess.Interfaces.Books;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.BooksVM;
using QamarKitoblar.Domain.Entities.Books;

namespace QamarKitoblar.DataAccess.Repositories.Books
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public Task<long> CountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<BookViewModel>> GetAllAsync(PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<BookViewModel> GetByIdAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<(int ItemsCount, IList<BookViewModel>)> SearchAsync(string search, PaginationParams @params)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(long id, Book entity)
        {
            throw new NotImplementedException();
        }
    }
}
