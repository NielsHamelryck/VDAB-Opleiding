using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestADOWPF
{
    public class MoetInVoorraadZijn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int vooraad;
            if (value == null || (((string)value).Length == 0))
            {
                return new ValidationResult(false, "Getal moet ingevuld zijn");
            }

            if(!int.TryParse(value.ToString(),out vooraad))
            {
                return new ValidationResult(false,"Dit veld moet een getal zijn");
            }
            if (vooraad <= 0)
            {
                return new ValidationResult(false,"Moet hoger dan 0 zijn");
            }
            return ValidationResult.ValidResult;
        
    }
    }
}
