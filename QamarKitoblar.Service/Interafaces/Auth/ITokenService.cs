using QamarKitoblar.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Interafaces.Auth;

public interface ITokenService
{
    public string GenerateToken(User user);

}
