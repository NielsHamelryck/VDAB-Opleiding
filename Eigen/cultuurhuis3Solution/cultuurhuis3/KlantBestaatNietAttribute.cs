using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using cultuurhuis3.Models;
using cultuurhuis3.services;

namespace cultuurhuis3
{
    public class KlantBestaatNietAttribute : ValidationAttribute
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
            services.CultuurhuisService db = new CultuurhuisService();
            return !db.BestaatKlant((string)value);
        }
    }
}