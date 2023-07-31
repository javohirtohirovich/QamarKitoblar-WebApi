using QamarKitoblar.Domain.Enums;

namespace QamarKitoblar.Service.Dtos.Orders;

public class OrderUpdateDto
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public PaymentType PaymentType { get; set; }

    public string Description { get; set; } = String.Empty;
}
