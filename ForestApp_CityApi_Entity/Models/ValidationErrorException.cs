using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_Entity.Models
{
    public class ValidationErrorException
    {
        public List<ValidationErrorExceptionModel> Errors { get; set; } = new List<ValidationErrorExceptionModel>();
    }
}
