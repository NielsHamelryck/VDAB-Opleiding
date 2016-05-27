using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddHerhaling;

namespace TDDHerhalingTests
{
    class OpbrengstDAOStub : IOpbrengstDAO
    {
        public decimal TotaleOpbrengst()
        {
            return 30;
        }
    }
}
