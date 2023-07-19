using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Books
{
    public class BookCommentNotFoundException : NotFoundException
    {
        public BookCommentNotFoundException() 
        {
            this.TitleMessage = "Book comment not found!";
        }
    }
}
