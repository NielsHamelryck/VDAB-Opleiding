using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TddHerhaling
{
    public class Winstservice
    {
        private IKostDAO kostDAO;
        private IOpbrengstDAO opbrengstDAO;
        public Winstservice(IKostDAO kostDAO, IOpbrengstDAO opbrengstDAO)
        {
            this.kostDAO = kostDAO;
            this.opbrengstDAO = opbrengstDAO;
        }
        public decimal Winst
        {
            get
            {
                return opbrengstDAO.TotaleOpbrengst()- kostDAO.TotaleKost();
            }
        }

    }
}
