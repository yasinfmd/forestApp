using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForestApp_IdentifiyApi.Validators
{
    public class CustomRegisterAgeValidation
    {
        public bool ValidAge(DateTime birthdate)
        {
           var yearDiff= DateTime.Now - birthdate;
            if(yearDiff.TotalDays> 5475)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
