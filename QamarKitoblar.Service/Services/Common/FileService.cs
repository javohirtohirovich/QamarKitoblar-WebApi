using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Interafaces.Common;



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
    public async Task<bool> DeleteAvatarAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        string newAvatarName = MediaHelper.MakeImageName(avatar.FileName);
        string subpath = Path.Combine(MEDIA, AVATAR, newAvatarName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await avatar.CopyToAsync(stream);
        stream.Close();
        return subpath;
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newImageName = MediaHelper.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGE, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();
        return subpath;
    }
}
