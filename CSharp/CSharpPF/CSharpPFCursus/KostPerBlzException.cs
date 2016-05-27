using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class KostPerBlzException : Exception
    {
        private decimal verkeerdeKostValue;

        public decimal VerkeerdeKost
        {
            get { return verkeerdeKostValue; }
            set { verkeerdeKostValue = value; }
        }

        
        
    }
}
