using QamarKitoblar.DataAccess.Common.Interfaces;
using QamarKitoblar.Domain.Entities.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.Interfaces.Discounts
{
    public interface IDiscountRepository:IRepository<Discount,Discount>,IGetAll<Discount>
    {
    }
}
