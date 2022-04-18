using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionary.Validations
{
    public class PhoneValidation:RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (base.IsValid(value))
            {
                return false;
            }
            long val = 0;
            if (long.TryParse(value.ToString(),out val))
            {
                ErrorMessage = "Telefon yalnızca rakam içermelidir";
                return false;
            }
            if (value.ToString().StartsWith("0"))
            {
                ErrorMessage = "Telefon 0 ile başlamalı!";
                return false;
            }
           // if (value.ToString()[0]!='0')
            return true;
        }
    }
}
