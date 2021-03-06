﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForestAppBase.Models
{
    public class ErrorModel
    {
        public string Key { get; set; }
        public string Message { get; set; }

        public ErrorModel(string key, string message)
        {
            this.Key = key;
            this.Message = message;
        }
    }
}
