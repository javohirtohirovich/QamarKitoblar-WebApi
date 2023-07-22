namespace QamarKitoblar.Domain.Exceptions.Books;

public class BookNotFoundException : NotFoundException
{
    public BookNotFoundException()
    {
        this.TitleMessage = "Book not found!";
    }
}