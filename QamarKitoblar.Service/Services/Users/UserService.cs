using Microsoft.AspNetCore.Server.IIS.Core;
using QamarKitoblar.DataAccess.Interfaces.Users;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.UsersVM;
using QamarKitoblar.Domain.Entities.Publishers;
using QamarKitoblar.Domain.Entities.Users;
using QamarKitoblar.Domain.Exceptions.File;
using QamarKitoblar.Domain.Exceptions.Users;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;

    public UserService(IUserRepository userRepository,IFileService fileService)
    {
        this._repository=userRepository;
        this._fileService=fileService;
    }
    public async Task<long> CountAsync()
    {
        var result =await  _repository.CountAsync();
        return result;
    }

    public async Task<bool> DeleteAsync(long PublisherId)
    {
       /* var result = await _repository.GetByIdAsync(PublisherId);
        if(result is null) { throw new UserNotFoundException(); }

        if (result.ImagePath is not null) 
        {
            var Delresult = await _fileService.DeleteImageAsync(result.ImagePath);
            if (Delresult is false) { throw new ImageNotFoundException(); }
        }*/

        var dbResult=await _repository.DeleteAsync(PublisherId);
        return dbResult > 0;
    }

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        return result;
    }

    
}
