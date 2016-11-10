using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MVC_CultuurHuisSelf.Services;

namespace MVC_CultuurHuisSelf
{
    public class GebruikerBestaatNogNiet : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value==null)
            {
                return true;
            }
            if (!(value is string))
            {
                return false;
            }
            else
            {
                Services.CultuurhuisService db =  new CultuurhuisService();
                return !db.BestaatKlant((string)value);
            }
        }
    }
}