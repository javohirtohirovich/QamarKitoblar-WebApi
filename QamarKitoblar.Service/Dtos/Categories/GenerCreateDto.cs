using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Dtos.Categories
{
    public class GenerCreateDto
    {
        [MaxLength(50)]
        public string Name { get; set; }=String.Empty;
        public string Description { get; set; } = String.Empty;
    }
}
