using QamarKitoblar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Interafaces.Auth;

public interface IIdentityService
{
    public long UserId { get; }

    public string FirstName { get; }

    public string LastName { get; }

    public string PhoneNumber { get; }

    public IdentityRole? IdentityRole { get; }
}
