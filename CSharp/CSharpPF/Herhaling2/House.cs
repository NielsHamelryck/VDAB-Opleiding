using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class House
    {
        public decimal Area { get; set; }
        public House()
        {
            Area = 200;
        }
        public House(decimal area)
        {
            this.Area = area;
        }

        public virtual void ShowData()
        {
            Persoon.Showdata();
            Console.WriteLine("I am a house, My area is {0} m2",Area);
            Door.ShowData();
        }

        private Door doorValue;

        public Door Door
        {
            get { return doorValue; }
            set { doorValue = value; }
        }

        private Persoon persoonValue;

        public Persoon Persoon
        {
            get { return persoonValue; }
            set { persoonValue = value; }
        }
        
    }
}
