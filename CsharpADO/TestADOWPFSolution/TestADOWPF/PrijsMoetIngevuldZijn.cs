using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestADOWPF
{
    public class PrijsMoetIngevuldZijn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal prijs;
            NumberStyles style= NumberStyles.Currency;
            if (value == null || (((string)value).Length == 0))
            {
                return new ValidationResult(false, "Getal moet ingevuld zijn");
            }

            if (!decimal.TryParse(value.ToString(),style,cultureInfo, out prijs))
            {
                return new ValidationResult(false, "Dit veld moet een getal zijn");
            }
            if (prijs <= 0)
            {
                return new ValidationResult(false, "Prijs mag niet negatief zijn of 0");
            }
            return ValidationResult.ValidResult;
        }
    }
}
