namespace QamarKitoblar.Domain.Entities.Discounts
{
    public sealed class BookDiscounts : Auditable
    {
        public long BookId { get; set; }
        public long DiscountId { get; set; }
        public string Description { get; set; } = String.Empty;
        public short Percentage { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }

    }
}
