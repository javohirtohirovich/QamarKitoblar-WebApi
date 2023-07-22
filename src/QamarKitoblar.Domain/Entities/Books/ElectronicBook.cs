using System.ComponentModel.DataAnnotations;

namespace QamarKitoblar.Domain.Entities.Books
{
    public sealed class ElectronicBook : Auditable
    {
        public long BookId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public string BookPath { get; set; } = String.Empty;


    }
}
