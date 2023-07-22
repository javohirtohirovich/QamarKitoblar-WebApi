using System.ComponentModel.DataAnnotations;

namespace QamarKitoblar.Domain.Entities.Books
{
    public sealed class Book : Auditable
    {
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        [MaxLength(50)]
        public string Author { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public double UnitPrice { get; set; }
        public bool IsHaveElectron { get; set; } = false;
        public long GenerId { get; set; }
        public long PublisherId { get; set; }
    }
}
