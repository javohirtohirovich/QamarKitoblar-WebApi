using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Entities.Orders
{
    public sealed class OrderDetail:Auditable
    {
        public long OrderId { get;set; }
        public long BookId { get;set; }
        public int Quantity { get;set; }
        public double TotalPrice { get; set; }
        public double DiscountPrice { get;set; }
        public double ResultPrice { get;set; }

    }
}
