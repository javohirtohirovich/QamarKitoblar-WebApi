using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Entities.Books
{
    public sealed class BookComent:Auditable
    {
        public long BookId { get; set; }
        public long UserId { get;set; }
        public string Comment { get; set; } = String.Empty;
        public bool IsEdited { get; set; }=false;

    }
}
