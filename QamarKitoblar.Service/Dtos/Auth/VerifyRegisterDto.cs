using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.Service.Dtos.Auth;

public class VerifyRegisterDto
{
    public string PhoneNumber { get; set; } = String.Empty;

    public int Code { get; set; }
}
