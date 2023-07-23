using Microsoft.Extensions.Caching.Memory;
using QamarKitoblar.DataAccess.Interfaces.Users;
using QamarKitoblar.Domain.Exceptions.Users;
using QamarKitoblar.Service.Common.Helpers;
using QamarKitoblar.Service.Dtos.Auth;
using QamarKitoblar.Service.Dtos.Notifcations;
using QamarKitoblar.Service.Dtos.Security;
using QamarKitoblar.Service.Interafaces.Auth;
using QamarKitoblar.Service.Interafaces.Notifcations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IMemoryCache _memoryCache;
    private readonly IUserRepository _userRepository;
    private readonly ISmsSender _smsSender;
    private const int CACHED_MINUTES_FOR_REGISTER = 60;
    private const int CACHED_MINUTES_FOR_VERIFICATION = 5;
    private const string REGISTER_CACHE_KEY = "register_";


    public AuthService(IMemoryCache memoryCache,IUserRepository userRepository, ISmsSender smsSender)
    {
        this._memoryCache = memoryCache;
        this._userRepository = userRepository;
        this._smsSender = smsSender;

    }
#pragma warning disable
    public async Task<(bool Result, int CachedMinutes)> RegisterAsync(RegisterDto dto)
    {
        var user = await _userRepository.GetByPhoneAsync(dto.PhoneNumber);
        if (user is not null) throw new UserAlreadyExistsExcaption(dto.PhoneNumber);

        // delete if exists user by this phone number
        if (_memoryCache.TryGetValue(dto.PhoneNumber, out RegisterDto cachedRegisterDto))
        {
            cachedRegisterDto.FirstName = cachedRegisterDto.FirstName;
            _memoryCache.Remove(dto.PhoneNumber);
        }
        else _memoryCache.Set(dto.PhoneNumber, dto,
            TimeSpan.FromMinutes(CACHED_MINUTES_FOR_REGISTER));

        return (Result: true, CachedMinutes: CACHED_MINUTES_FOR_REGISTER);
    }

    public async Task<(bool Result, int CachedVerificationMinutes)> SendCodeForRegisterAsync(string phone)
    {
        if (_memoryCache.TryGetValue(phone, out RegisterDto registerDto))
        {
            VerificationDto verificationDto = new VerificationDto();
            verificationDto.Attempt = 0;
            verificationDto.CreatedAt = TimeHelper.GetDateTime();

            // make confirm code as random
            verificationDto.Code = 11111;

            _memoryCache.Set(phone, verificationDto, 
                TimeSpan.FromMinutes(CACHED_MINUTES_FOR_VERIFICATION));

            //sms sender::begin
            //sms sender::end

            return (Result: true, CachedVerificationMinutes: CACHED_MINUTES_FOR_VERIFICATION);
        }
        else throw new UserCacheDataExpiredException();
    }

    public async Task<(bool Result, string Token)> VerifyRegisterAsync(string phone, int code)
    {
        throw new NotImplementedException();
    }
}
