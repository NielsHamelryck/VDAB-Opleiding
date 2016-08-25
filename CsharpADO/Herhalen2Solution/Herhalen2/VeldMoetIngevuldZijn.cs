using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Herhalen2
{
    public class VeldMoetIngevuldZijn  :ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == String.Empty)
            {
                return new ValidationResult(false,"Veld moet ingevuld zijn");
            }
            return ValidationResult.ValidResult;
        }
    }
}
