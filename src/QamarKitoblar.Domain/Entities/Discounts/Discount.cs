using System.ComponentModel.DataAnnotations;

namespace QamarKitoblar.Domain.Entities.Discounts
{
    public sealed class Discount : Auditable
    {
        [MaxLength(50)]
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;

    }
}
