using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TestADOWPF
{
    public class MoetGeldigeGenreZijnGeselecteerd : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (int.Parse(value.ToString()) == 0)
            {
                return new ValidationResult(false, "Genre moet gekozen worden");
            }

            return ValidationResult.ValidResult;
        }
    }
}
