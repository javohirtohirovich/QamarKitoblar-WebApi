using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Dtos.Discounts;

public class DiscountUpdateDto
{
    public string Name { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
}
