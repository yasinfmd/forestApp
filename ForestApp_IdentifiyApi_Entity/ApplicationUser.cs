using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_IdentifiyApi_Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public int PasswordResetCount { get; set; }

        public string Gender { get; set; }

        public virtual IEnumerable<UserOldPasswords>? UserOldPasswords { get; set; }
    }
}
