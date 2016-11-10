using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbereiding
{
    class Triangle : Shape
    {
        private int width;
        private int height;

        public Triangle(int width, int height)
        {
            this.width = width;
            this.height = height;
        }
        public override int area()
        {
            Console.WriteLine("triangle class area");
            return (width*height/2);
        }
    }
}
