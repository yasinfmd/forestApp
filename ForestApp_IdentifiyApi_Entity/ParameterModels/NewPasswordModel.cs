using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_IdentifiyApi_Entity.ParameterModels
{
    public class NewPasswordModel
    {
        public string NewPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
