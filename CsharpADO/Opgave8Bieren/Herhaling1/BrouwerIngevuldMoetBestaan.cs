using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using AdoGemeenschap;

namespace Herhaling1
{
    public class BrouwerIngevuldMoetBestaan : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           var manager = new BierManager();
            Dictionary<int,string> brouwers = new Dictionary<int, string>();
            brouwers = manager.GetDictionaryBrouwers();
            bool bestaat = false;
            if (value == null || (String) value == string.Empty)
            {
                return new ValidationResult(false,"Brouwer Moet ingevuld zijn");
            }
            foreach (var brouwer in brouwers )
            {
                if (value.ToString() == brouwer.Value)
                {
                    bestaat = true;
                }
            }
            if (!bestaat)
            {
                return new ValidationResult(false,"Ingevulde brouwer bestaat niet");
            }
            return ValidationResult.ValidResult;
        }
    }
}
