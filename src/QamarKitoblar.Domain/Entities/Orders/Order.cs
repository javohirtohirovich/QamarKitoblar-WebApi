using QamarKitoblar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Entities.Orders
{
    public sealed class Order:Auditable
    {
        public long UserId { get; set; }
        public OrderStatus Status { get; set; }

        // The summ of order details result prices
        // The monay which that user must pay for products
        public double BookPrice { get; set; }
        // The payment that user must pay for sales
        // Products Price + Delivery Price
        public double ResultPrice { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public PaymentType PaymentType { get; set; }

        public bool IsPaid { get; set; }

        public bool IsContracted { get; set; }

        public string Description { get; set; } = String.Empty;

    }
}
