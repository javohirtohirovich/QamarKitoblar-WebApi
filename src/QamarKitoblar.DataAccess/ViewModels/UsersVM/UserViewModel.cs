using QamarKitoblar.Domain.Entities;
using QamarKitoblar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QamarKitoblar.DataAccess.ViewModels.UsersVM
{
    public class UserViewModel:Auditable
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public bool PhoneNumberConfirmed { get; set; } = false;
        public string PassportSeriaNumber { get; set; } = String.Empty;
        public bool IsMale { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Country { get; set; } = String.Empty;
        public string Region { get; set; } = String.Empty;
        public string PostalNumber { get; set; } = String.Empty;       
        public string ImagePath { get; set; } = String.Empty;
        public DateTime LastActivity { get; set; } = DateTime.Now;
        public IdentityRole IndentityRole { get; set; }
    }
}
