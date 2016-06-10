using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace VerkeerslichtMVVM.Model
{
    public class VerkeersLicht 
    {
        public int RoodLicht { get; set; }
        public int OranjeLicht { get; set; }

        public int GroenLicht { get; set; }

       public string Actief { get; set; }

        public Boolean WasRood { get; set; }

        public VerkeersLicht()
        {
            RoodLicht =1;
            OranjeLicht = 0;
            GroenLicht = 0;
            WasRood = true;


        }
    }
}
