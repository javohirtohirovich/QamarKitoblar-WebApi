using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Publishers
{
    public class PublisherNotFoundException:NotFoundException
    {
        public PublisherNotFoundException() 
        {
            this.TitleMessage = "Publisher not found!";
        }
    }
}
