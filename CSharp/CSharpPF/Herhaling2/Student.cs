using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herhaling2
{
    public class Student : Persoon
    {
        public void GoToClasses()
        {
            Console.WriteLine("I'm going to class.");
        }
        public void ShowAge()
        {   
            
            Console.WriteLine("My age is: {0} years old.",Age);
        }
        public Student(string naam )
            : base(naam)
        {

        }
        public override void Greet()
        {
            base.Greet();
            ShowAge();
        }
        
    }
}
