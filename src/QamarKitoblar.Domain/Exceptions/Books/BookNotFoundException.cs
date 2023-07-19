using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Books;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException() 
    {
        this.TitleMessage = "Book not found!";
    }
}