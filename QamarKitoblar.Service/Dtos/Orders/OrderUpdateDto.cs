using QamarKitoblar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Dtos.Orders;

public class OrderUpdateDto
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public PaymentType PaymentType { get; set; }

    public string Description { get; set; } = String.Empty;
}
