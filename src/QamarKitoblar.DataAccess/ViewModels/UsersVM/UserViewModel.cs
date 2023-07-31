using QamarKitoblar.Domain.Entities;
using QamarKitoblar.Domain.Enums;

namespace QamarKitoblar.DataAccess.ViewModels.UsersVM
{
    public class UserViewModel : Auditable
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public bool PhoneNumberConfirmed { get; set; } = false;
        public string PassportSeriaNumber { get; set; } = String.Empty;
        public bool IsMale { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; } = String.Empty;
        public string Region { get; set; } = String.Empty;
        public string PostalNumber { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public DateTime LastActivity { get; set; } = DateTime.Now;
        public IdentityRole IdentityRole { get; set; }
    }
}
