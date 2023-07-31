using Microsoft.AspNetCore.Http;

namespace QamarKitoblar.Service.Dtos.Books;

public class BookCreateDto
{
    public string Name { get; set; } = String.Empty;
    public string Author { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public IFormFile? ImagePath { get; set; }
    public double UnitPrice { get; set; }
    public bool IsHaveElectron { get; set; } = false;
    public long GenerId { get; set; }
    public long PublisherId { get; set; }
}
