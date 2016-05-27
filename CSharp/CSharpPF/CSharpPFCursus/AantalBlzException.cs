using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class AantalBlzException : Exception
    {
        private int verkeerdAantal;

        public int VerkeerdAantal
        {
            get { return verkeerdAantal; }
            set { verkeerdAantal = value; }
        }
        
    }
}
