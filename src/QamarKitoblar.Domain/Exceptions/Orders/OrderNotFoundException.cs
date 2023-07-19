using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Orders
{
    public class OrderNotFoundException:NotFoundException
    {
        public OrderNotFoundException() 
        {
            this.TitleMessage = "Order not found!";
        }
    }
}
