using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TddHerhaling
{
    public class Woord
    {
        private string woord;
        public Woord(string woord)
        {
            this.woord = woord;
        }
        public bool IsPalindroom()
        {
            var ControleWoord = new String(woord.ToArray().Reverse().ToArray());
            return woord == ControleWoord;
        }
    }
}
