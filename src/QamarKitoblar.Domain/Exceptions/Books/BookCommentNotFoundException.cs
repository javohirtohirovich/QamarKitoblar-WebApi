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
