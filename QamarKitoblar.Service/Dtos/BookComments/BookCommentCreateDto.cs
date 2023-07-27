using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Dtos.BookComments;

public class BookCommentCreateDto
{
    public long BookId { get; set; }
    public long UserId { get; set; }
    public string Comment { get; set; } = String.Empty;
}
