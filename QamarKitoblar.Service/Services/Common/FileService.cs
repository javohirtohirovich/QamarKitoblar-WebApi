using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using QamarKitoblar.Service.Interafaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace QamarKitoblar.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGE = "images";
    private readonly string AVATAR = "avatars";
    private readonly string ROOTPATH;
    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }
    public Task<bool> DeleteAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteImageAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadImageAsync(IFormFile image)
    {
        throw new NotImplementedException();
    }
}
