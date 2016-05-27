using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    class Omzetter
    {
        public const double CmInch=2.54d;
        public double CmNaarInch(double cm)
        {
            
            return cm/CmInch;
        }
        public double InchNaarCm(double inch)
        {
            
            return inch*CmInch;
        }
    }
}
