using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbereiding
{
    public class Rectangle : Shape
    {
        private int width;
        private int length;

        public Rectangle(int width, int length)
        {
            this.width = width;
            this.length = length;
        }

        public override int area()
        {
            Console.WriteLine("Rectangle class area:");
            return (length*width);
        }
    }
}
