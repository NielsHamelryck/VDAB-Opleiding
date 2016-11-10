using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDCursusLibrary
{
    enum RomanNumeralsType
    {
        M = 1000,
        D= 500,
        C= 100,
        L= 50,
        X= 10,
        V= 5,
        I= 1
    }

    internal class RomanNumeralPair
    {
        public int NumericValue { get; set; }
        public String RomanNumeralRepresentation { get; set; }
    }
   
    
    public class RomanNumeralConverter
    {

        public string ConvertRomanNumeral(int getal)
        {

            StringBuilder resultaat = new StringBuilder();

            foreach (var result in _romanNumeralList)
            {
                while (getal >= result.NumericValue)
                {
                    resultaat.Append(result.RomanNumeralRepresentation);
                    getal -= result.NumericValue;
                }
            }

            return resultaat.ToString();
        }



        private readonly List<RomanNumeralPair> _romanNumeralList;

        public RomanNumeralConverter()
        {
            _romanNumeralList = new List<RomanNumeralPair>()
            {

                //1000
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.M),
                    RomanNumeralRepresentation = RomanNumeralsType.M.ToString()
                },
                //500
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.D),
                    RomanNumeralRepresentation = RomanNumeralsType.D.ToString()
                },
                //100
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.C),
                    RomanNumeralRepresentation = RomanNumeralsType.C.ToString()
                },
                //50
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.L),
                    RomanNumeralRepresentation = RomanNumeralsType.L.ToString()
                },
                //10
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.X),
                    RomanNumeralRepresentation = RomanNumeralsType.X.ToString()
                },
                //5
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.V),
                    RomanNumeralRepresentation = RomanNumeralsType.V.ToString()
                },
                //1
                new RomanNumeralPair()
                {
                    NumericValue = Convert.ToInt32(RomanNumeralsType.I),
                    RomanNumeralRepresentation = RomanNumeralsType.I.ToString()
                }



            };

        }


       
    }
}
