namespace QamarKitoblar.DataAccess.ViewModels.BooksVM;

public class BookViewModel
{
    public long Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string ImagePath { get; set; } = String.Empty;
    public double UnitPrice { get; set; }
    public bool IsHaveElectron { get; set; } = false;
    public long PublisherId { get; set; }
    public long GenerId { get; set; }
}
