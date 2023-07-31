using QamarKitoblar.Domain.Enums;

namespace QamarKitoblar.Service.Interafaces.Auth;

public interface IIdentityService
{
    public long UserId { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string PhoneNumber { get; }

    public IdentityRole? IdentityRole { get; }
}
