using System;
using System.Collections.Generic;
using System.Text;

namespace ForestApp_CityApi_Entity.Models
{
    public class ValidationErrorExceptionModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
