using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using AdoGemeenschap;

namespace AdoWPF
{
    public class PostcodeRangeRule : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Brouwer brouwer = (value as BindingGroup).Items[0] as Brouwer;
            if ((brouwer.Postcode < 1000) || (brouwer.Postcode > 9999))
            {
                return new ValidationResult(false, "Postcode moet tussen 1000 en 9999 liggen");
            }
            else return ValidationResult.ValidResult;
        }
    }
}
