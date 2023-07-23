using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Dtos.Auth;

public class RegisterDto
{
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string PhoneNumber { get; set; } = String.Empty;

    public string Password { get; set; } = string.Empty;

}
