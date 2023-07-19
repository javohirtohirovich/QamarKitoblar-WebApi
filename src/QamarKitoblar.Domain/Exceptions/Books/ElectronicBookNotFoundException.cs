using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Books
{
    public class ElectronicBookNotFoundException:NotFoundException
    {
        public ElectronicBookNotFoundException() 
        {
            this.TitleMessage = "Electron book not found!";
        }
    }
}
