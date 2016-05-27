using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    class SmallApartment : House
    {
        public SmallApartment():base(50)
        {

        }
        public override void ShowData()
        {
            Persoon.Showdata();
            Console.WriteLine("I am a apartment, my area is {0}m2",Area) ;
            Door.ShowData();
        }
    }
}
