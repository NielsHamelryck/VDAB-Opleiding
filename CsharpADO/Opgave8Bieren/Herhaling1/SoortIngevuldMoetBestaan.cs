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
    public class SoortIngevuldMoetBestaan : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
       {
            var manager = new BierManager();
            Dictionary<int,string> dictSoorten = new Dictionary<int, string>();
            bool bestaat = false;
            dictSoorten = manager.GetDictionarySoorten();
            if (value == null || value.ToString() == String.Empty)
            {
                return new ValidationResult(false, "Soort moet ingevuld zijn");
            }
            
                foreach (var soort in dictSoorten)
                {
                    if (value.ToString() == soort.Value)
                    {
                        bestaat = true;
                    }
                }
                if (!bestaat)
                {
                    return new ValidationResult(false, "Ingevulde soort bestaat niet");
                }
            
            return ValidationResult.ValidResult;
        }
    }
}
