using System;

namespace TestPF
{
    internal class Apple
    {
        private int unknown;
        private string _groen;

        public string Groen
        {
            get { return _groen; }
            set { _groen = value; }
        }

        public int I
        {
            get { return unknown; }
            set { unknown = value; }
        }

        public Apple(string groen, int i)
        {
            Groen = groen;
            I = i;
            throw new NotImplementedException();
        }
    }
}