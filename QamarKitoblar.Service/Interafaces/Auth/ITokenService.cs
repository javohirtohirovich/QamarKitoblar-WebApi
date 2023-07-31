using QamarKitoblar.Domain.Entities.Users;

namespace QamarKitoblar.Service.Interafaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);

}
