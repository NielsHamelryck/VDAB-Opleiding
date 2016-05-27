using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Persoon
    {
        public string Naam { get; set; }
       

        protected int Age;
        
        public int SetAge(int n)
        {
            return Age=n;
        }

        public Persoon()
        {
            this.Naam = "onbekend";
            this.Age = 99;
            
        }
        public Persoon(string naam,int age=0)
        {
            this.Naam = naam;
            this.Age = age;
            
        }
        public void Showdata()
        {
            Console.WriteLine("Name: "+Naam);

        }

        public virtual void Greet()
        {
            Console.WriteLine("Hello");
        }
    }
}
