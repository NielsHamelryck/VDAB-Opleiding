using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public static class MyStringExtensions
    {
        public static string ToUpperFirst(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
        public static string Right(this string s, int aantal)
        {
            if (s.Length <= aantal)
                return s;
            else return s.Substring(s.Length - aantal);

        }
        
    }
}
