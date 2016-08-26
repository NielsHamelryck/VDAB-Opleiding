using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoGemeenschappelijk
{
    public class Film
    {
        public bool Changed { get; set; }
        private int bandNRValue;

        public int BandNr
        {
            get { return bandNRValue; }
            set { bandNRValue = value; }
        }

        private String titelValue;

        public String Titel
        {
            get { return titelValue; }
            set
            {
                titelValue = value;
                Changed = true;
            }
        }

        private Int32 genreNRValue;

        public Int32 GenreNr
        {
            get { return genreNRValue; }
            set { genreNRValue = value; }
        }

        private Int32 inVoorraadValue;

        public Int32 InVoorraad
        {
            get { return inVoorraadValue; }
            set
            {
                inVoorraadValue = value;
                Changed = true;
            }
        }

        private Int32 uitVoorraadValue;

        public Int32 UitVoorraad
        {
            get { return uitVoorraadValue; }
            set
            {
                uitVoorraadValue = value;
                Changed = true;
            }
        }

        private Decimal prijsValue;

        public Decimal Prijs
        {
            get { return prijsValue; }
            set
            {
                prijsValue = value;
                Changed = true;
            }
        }

        private Int32 totaalVerhuur;

        public Int32 TotaalVerhuurd
        {
            get { return totaalVerhuur; }
            set
            {
                totaalVerhuur = value;
                Changed = true;
            }
        }

        public Film(int bandNrValue, string titelValue, int genreNrValue, int inVoorraadValue, int uitVoorraadValue,
            decimal prijsValue, int totaalVerhuur)
        {
            bandNRValue = bandNrValue;
            this.titelValue = titelValue;
            genreNRValue = genreNrValue;
            this.inVoorraadValue = inVoorraadValue;
            this.uitVoorraadValue = uitVoorraadValue;
            this.prijsValue = prijsValue;
            this.totaalVerhuur = totaalVerhuur;
            Changed = false;
            }

        public Film()
        {
            
        }
    }
}
