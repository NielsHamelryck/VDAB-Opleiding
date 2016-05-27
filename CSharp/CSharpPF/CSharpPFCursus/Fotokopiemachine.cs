using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firma.Materiaal
{   public delegate void Onderhoudsbeurt(Fotokopiemachine machine);
    public class Fotokopiemachine :IKost
    {
        public class KostPerBlzException : Exception
        {
            private decimal verkeerdeKostValue;

            public decimal VerkeerdeKost
            {
                get { return verkeerdeKostValue; }
                set { verkeerdeKostValue = value; }
            }
            public KostPerBlzException(String message, decimal verkeerdekost):base(message)
            {
                VerkeerdeKost = verkeerdekost;
            }
        }
        public class AantalBlzException : Exception
        {
            private int verkeerdAantal;

            public int VerkeerdAantal
            {
                get { return verkeerdAantal; }
                set { verkeerdAantal = value; }
            }
            public AantalBlzException(String message, int verkeerdaantal)
                : base(message)
            {
                VerkeerdAantal = verkeerdaantal;
            }

        }

        public event Onderhoudsbeurt OnderhoudNodig;
        private const int AantalBlzTussen2OnderhoudsBeurten = 10;
        public void Fotokopieer(int aantalBlz)
        {
            for (int blz = 1; blz <= aantalBlz; blz++)
            {
                Console.WriteLine("FotokopieMachine {0} kopieert" + "blz. {1} van {2}",SerieNummer,blz,aantalBlz);
                if (++AantalBlz % AantalBlzTussen2OnderhoudsBeurten == 0)
                    if (OnderhoudNodig != null)
                        OnderhoudNodig(this);
            }
        }
        private String serienummerValue;

        public String SerieNummer
        {
            get { return serienummerValue; }
            set { serienummerValue = value; }
        }
        private int aantalBlzValue;

        public int AantalBlz
        {
            get { return aantalBlzValue; }
            set 
            {
                if (value < 0)
                    throw new AantalBlzException("Aantal blz. <0!",value);
                aantalBlzValue = value; 
            }
        }
        private decimal kostPerBlz;

        public decimal KostPerBlz
        {
            get { return kostPerBlz; }
            set
            {
                if (value <= 0)
                    throw new KostPerBlzException("kostprijs per blz <0!",value);
                kostPerBlz = value; }
        }
        public Fotokopiemachine(string serieNr , int aantalBlz,decimal kostPerBlz)
        {
            this.SerieNummer = serieNr;
            this.AantalBlz = aantalBlz;
            this.KostPerBlz = kostPerBlz;
        }
        
        
        
        public decimal Bedrag
        {
            get { return AantalBlz*KostPerBlz;} 
        }

        public bool Menselijk
        {
            get { return false; }
        }
    }
}
