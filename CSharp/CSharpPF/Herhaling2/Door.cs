using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Door
    {
        public string Color { get; set; }

        public void ShowData()
        {
            Console.WriteLine("I am a Door, my color is {0}",Color);
        }

        public Door()
        {
            this.Color = "onbekend";
        }

        public Door(string kleur)
        {
            this.Color = kleur;
        }
    }
}
