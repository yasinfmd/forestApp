using System;
using System.Collections.Generic;
using System.Text;

namespace ForestAppBase.Models
{
    public class ValidationErrorExceptionModel
    {
        public string FieldName { get; set; }
        public string Message { get; set; }
    }
}
