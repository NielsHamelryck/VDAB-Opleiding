using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Herhaling1
{
    public class NaamMoetIngevuldZijn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == String.Empty)
            {
                return new ValidationResult(false, "Naam moet ingevuld zijn voordat je verder kan gaan");
            }
            return ValidationResult.ValidResult;
        }
    }
}
