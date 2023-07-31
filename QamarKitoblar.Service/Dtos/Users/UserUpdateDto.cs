using Microsoft.AspNetCore.Http;

namespace QamarKitoblar.Service.Dtos.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public string PassportSeriaNumber { get; set; } = String.Empty;
    public bool IsMale { get; set; }
    public DateTime BirthDate { get; set; }
    public string Country { get; set; } = String.Empty;
    public string Region { get; set; } = String.Empty;
    public string PostalNumber { get; set; } = String.Empty;
    public IFormFile? ImagePath { get; set; }
}
