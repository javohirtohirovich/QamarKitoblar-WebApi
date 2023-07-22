using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.File;

public class ImageNotFoundException:NotFoundException
{
    public ImageNotFoundException() 
    {
        TitleMessage = "Image not found!";
    }
}
