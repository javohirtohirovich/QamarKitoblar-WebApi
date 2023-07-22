namespace QamarKitoblar.Domain.Entities
{
    public abstract class Auditable : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
