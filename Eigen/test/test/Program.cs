using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

            var evenNumbers = (from number in numbers
                where number%2 == 0
                select number).ToList();

            foreach (var number in evenNumbers)
            {
                Console.WriteLine(number + " - ");
            }

        }
    }
}
