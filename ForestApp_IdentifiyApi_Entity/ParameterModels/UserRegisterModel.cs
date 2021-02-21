using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_IdentifiyApi_Entity.ParameterModels
{
    public class UserRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }
    }
}
