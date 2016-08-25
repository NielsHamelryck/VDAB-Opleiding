using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HerhalingWPFOpgave8
{
    public class VeldMoetIngevuldZijn : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == String.Empty)
            {
                return  new ValidationResult( false , "Veld Moet ingevuld zijn");
            }


            return ValidationResult.ValidResult;
        }
    }
}
