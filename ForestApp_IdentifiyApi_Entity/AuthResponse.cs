using ForestAppBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_IdentifiyApi_Entity
{
    public class AuthResponse<T> where T : class
    {
        public T Result { get; set; }
        public bool? isSuccess { get; set; }

        public DateTime? ExpireDate { get; set; }

        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
