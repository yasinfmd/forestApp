using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_IdentifiyApi_Entity
{
    public class UserOldPasswords
    {
        public Guid Id { get; set; }

        public DateTime PasswordDate { get; set; }

        public Guid? UserId { get; set; }

        public  ApplicationUser ApplicationUser;

    }
}
