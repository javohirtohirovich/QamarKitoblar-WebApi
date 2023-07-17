using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Entities
{
    public abstract class Auditable:BaseEntity
    {
        public DateTime CreatedAt { get; set; }= DateTime.Now;
        public DateTime UpdatedAt { get; set;}=DateTime.Now;
    }
}
