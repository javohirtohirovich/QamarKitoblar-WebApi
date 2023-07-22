using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string extension=fileInfo.Extension;
        string name="IMG_"+Guid.NewGuid().ToString()+extension;
        return name;
    }
}
