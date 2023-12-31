﻿using Microsoft.AspNetCore.Http;

namespace QamarKitoblar.Service.Interafaces.Common
{
    public interface IFileService
    {
        public Task<string> UploadImageAsync(IFormFile image);
        public Task<bool> DeleteImageAsync(string subpath);
        public Task<string> UploadAvatarAsync(IFormFile avatar);
        public Task<bool> DeleteAvatarAsync(string subpath);

    }
}
