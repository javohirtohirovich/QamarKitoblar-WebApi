namespace QamarKitoblar.Service.Dtos.BookComments;

public class BookCommentCreateDto
{
    public long BookId { get; set; }
    public string Comment { get; set; } = String.Empty;
}
