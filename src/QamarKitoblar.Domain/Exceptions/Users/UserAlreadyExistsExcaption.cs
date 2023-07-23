using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Domain.Exceptions.Users;

public class UserAlreadyExistsExcaption:AlreadyExistsExcaption
{
    public UserAlreadyExistsExcaption()
    {
        TitleMessage = "User already exists";
    }

    public UserAlreadyExistsExcaption(string phone)
    {
        TitleMessage = "This phone is already registered";
    }

}
