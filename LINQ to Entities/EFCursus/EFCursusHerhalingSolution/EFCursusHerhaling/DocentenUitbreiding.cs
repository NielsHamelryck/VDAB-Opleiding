using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCursusHerhaling
{
    public partial class Docent 
    {
      
        public void Opslag(decimal bedrag)
        {
            Wedde += bedrag;
        }
    }
}
