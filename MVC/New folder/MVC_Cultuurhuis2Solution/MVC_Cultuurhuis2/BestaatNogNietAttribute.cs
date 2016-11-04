using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Cultuurhuis2.Services;

namespace MVC_Cultuurhuis2
{
    public class BestaatNogNietAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            if (!(value is string))
            {
                return false;
            }
            else
            {
                Services.CultuurhuisService db = new CultuurhuisService();
                return !db.BestaatKlant((string) value);
            }
        }
    }
}