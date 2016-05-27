using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestPF
{
    class OngeldigEmailadresException : Exception
    {
        public OngeldigEmailadresException(string adres)
        {
            throw new Exception(adres+" is een ongeldig Email adres.");
        }
    }
}
