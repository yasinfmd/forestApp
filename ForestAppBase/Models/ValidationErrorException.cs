using System;
using System.Collections.Generic;
using System.Text;

namespace ForestAppBase.Models
{
    public class ValidationErrorException
    {
        public List<ValidationErrorExceptionModel> Errors { get; set; } = new List<ValidationErrorExceptionModel>();
    }
}
