using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBierenApplication.ValidationAttributen
{
    public class AlcoholGrenzenAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (!(value is float))
            {
                return false;
            }
            return (float) value < 15 && (float) value > 0;
        }
    }
}