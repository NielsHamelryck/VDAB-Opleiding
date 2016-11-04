using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Cultuurhuis2
{
    public class MaxAantalPlaatsen : ValidationAttribute
    {
        public override bool IsValid(object value )
        {
            

            if (value == null)
            {
                return true;
            }
            if (!(value is Int16))
            {
                return false;
            }
            return ((Int16)value <= 170);
        }
    }
}