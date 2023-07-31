using QamarKitoblar.DataAccess.Interfaces.Users;
using QamarKitoblar.DataAccess.Utils;
using QamarKitoblar.DataAccess.ViewModels.UsersVM;
using QamarKitoblar.Domain.Exceptions.File;
using QamarKitoblar.Domain.Exceptions.Users;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Users;
using QamarKitoblar.Service.Interafaces.Common;
using QamarKitoblar.Service.Interafaces.Users;

namespace QamarKitoblar.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IFileService _fileService;
    private readonly IPaginator _paginator;

    public UserService(IUserRepository userRepository, IFileService fileService, IPaginator paginator)
    {
        this._repository = userRepository;
        this._fileService = fileService;
        this._paginator = paginator;
    }
    public async Task<long> CountAsync()
    {
        var result = await _repository.CountAsync();
        return result;
    }

    public async Task<bool> DeleteAsync(long PublisherId)
    {
        var result = await _repository.GetByIdAsync(PublisherId);
        if (result is null) { throw new UserNotFoundException(); }

        if (result.ImagePath is not null)
        {
            var Delresult = await _fileService.DeleteImageAsync(result.ImagePath);
            if (Delresult is false) { throw new ImageNotFoundException(); }
        }

        var dbResult = await _repository.DeleteAsync(PublisherId);
        return dbResult > 0;
    }

    public async Task<IList<UserViewModel>> GetAllAsync(PaginationParams @params)
    {
        var result = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<UserViewModel> GetByIdAsync(long UserId)
    {
        var result = await _repository.GetByIdAsync(UserId);
        if (result is null) { throw new UserNotFoundException(); }
        else { return result; }
    }

    public async Task<(long ItemsCount, IList<UserViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        var result = await _repository.SearchAsync(search, @params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return result;
    }

    public async Task<bool> UpdateAsync(long UserId, UserUpdateDto userUpdateDto)
    {
        var user = await _repository.GetByIdCheckUser(UserId);
        if (user is null) { throw new UserNotFoundException(); }

        if (userUpdateDto.ImagePath is not null)
        {
            //Delete old image
            if (user.ImagePath != "")
            {
                var deleteResult = await _fileService.DeleteAvatarAsync(user.ImagePath);
                if (deleteResult == false) { throw new ImageNotFoundException(); }
            }
            //Upload image

            var newImagePath = await _fileService.UploadAvatarAsync(userUpdateDto.ImagePath);

            //save new path in publisher
            user.ImagePath = newImagePath;
        }

        user.FirstName = userUpdateDto.FirstName;
        user.LastName = userUpdateDto.LastName;
        user.PhoneNumber = userUpdateDto.PhoneNumber;
        user.Country = userUpdateDto.Country;
        user.Region = userUpdateDto.Region;
        user.IsMale = userUpdateDto.IsMale;
        user.BirthDate = userUpdateDto.BirthDate;
        user.PostalNumber = userUpdateDto.PostalNumber;
        user.PassportSeriaNumber = userUpdateDto.PassportSeriaNumber;
        user.UpdatedAt = TimeHelper.GetDateTime();

        var result = await _repository.UpdateAsync(UserId, user);
        return result > 0;
    }
}
