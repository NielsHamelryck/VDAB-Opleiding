using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddHerhaling;

namespace TDDHerhalingTests
{
    public class KostDAOStub : IKostDAO
    {
        public decimal TotaleKost()
        {
            return 10;
        }
    }
}
