﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Discounts
{
    public class DiscountNotFoundException:NotFoundException
    {
        public DiscountNotFoundException() 
        {
            this.TitleMessage = "Discount not found!";
        }
    }
}
