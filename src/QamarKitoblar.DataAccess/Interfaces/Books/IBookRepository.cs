using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.DataAccess.ViewModels.BooksVM;
using QamarKitoblar.Domain.Entities.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Interfaces.Books
{
    public interface IBookRepository:IRepository<Book,BookViewModel>,IGetAll<BookViewModel>,ISearchable<BookViewModel>
    {
    }
}
