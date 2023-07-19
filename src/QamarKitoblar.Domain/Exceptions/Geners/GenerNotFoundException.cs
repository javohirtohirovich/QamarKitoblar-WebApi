using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Geners
{
    public class GenerNotFoundException:NotFoundException
    {
        public GenerNotFoundException() 
        {
            this.TitleMessage = "Gener not found!";
        }
    }
}
