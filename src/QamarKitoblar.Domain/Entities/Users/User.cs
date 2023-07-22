using QamarKitoblar.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace QamarKitoblar.Domain.Entities.Users
{
    public sealed class User : Auditable
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = String.Empty;
        [MaxLength(50)]
        public string LastName { get; set; } = String.Empty;
        [MaxLength(13)]
        public string PhoneNumber { get; set; } = String.Empty;
        public bool PhoneNumberConfirmed { get; set; } = false;
        [MaxLength(9)]
        public string PassportSeriaNumber { get; set; } = String.Empty;
        public bool IsMale { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Country { get; set; } = String.Empty;
        public string Region { get; set; } = String.Empty;
        [MaxLength(7)]
        public string PostalNumber { get; set; } = String.Empty;
        public string PasswordHash { get; set; } = String.Empty;
        public string Salt { get; set; } = String.Empty;
        public string ImagePath { get; set; } = String.Empty;
        public DateTime LastActivity { get; set; } = DateTime.Now;
        public IdentityRoleEnum IndentityRole { get; set; }

    }
}
