using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions
{
    public class BadRequestException:Exception
    {
        public  HttpStatusCode StatusCode { get; } = HttpStatusCode.BadRequest;

        public  string TitleMessage { get; protected set; } = String.Empty;
    }
}
