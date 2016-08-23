using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace WPFOpgave8
{
    public class VeldMoetIngevuldZijn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            if (value == null || (((String) value).Length == 0))
            {
                return new ValidationResult(false,"Veld moet ingevuld zijn");
            }
            return ValidationResult.ValidResult;
        }
    }
}
