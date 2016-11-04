using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_Cultuurhuis.Services;

namespace MVC_Cultuurhuis
{
    public class BestaatnognietAttribute : ValidationAttribute
    {
        public override bool IsValid(object Value)
        {
            if (Value == null)
            {
                return true;
            }
            if (!(Value is string))
            {
                return false;
            }
            else
            {
                Services.CultuurService db = new CultuurService();
                return !db.BestaatKlant((string) Value);
            }
        }
    }
}