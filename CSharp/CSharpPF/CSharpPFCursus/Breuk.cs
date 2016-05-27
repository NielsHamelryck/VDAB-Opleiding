using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public class Breuk
    {
        private int tellerValue;

        public int Teller
        {
            get { return tellerValue; }
            set 
            {   
                tellerValue = value; }
        }
        private int noemerValue;

        public int Noemer
        {
            get { return noemerValue; }
            set
            {
                if (value == 0)
                    throw new Exception("Noemer mag geen nul zijn !");
                noemerValue = value; }
        }
        public Breuk(int teller, int noemer)
        {
            this.Teller = teller;
            this.Noemer = noemer;
        }
        public override string ToString()
        {
            return Teller + "/" +Noemer;
        }
        public override bool Equals(object obj)
        {
            if (obj is Breuk)
            {
                Breuk andereBreuk = (Breuk)obj;
                return (decimal)Teller / Noemer == (decimal)andereBreuk.Teller / andereBreuk.Noemer;
            }
            else return false;
        }
        public override int GetHashCode()
        {
            return Teller + Noemer;
        }
        
        public static bool operator ==(Breuk eerste,Breuk tweede)
        {
            return eerste.Equals(tweede);
        }
        public static bool operator !=(Breuk eerste, Breuk tweede)
        {
            return !eerste.Equals(tweede);
        }

        public static Breuk operator *(Breuk eerste, Breuk tweede)
        {
            return new Breuk(eerste.Teller * tweede.Teller, eerste.Noemer * tweede.Noemer);
        }
        public static Breuk operator *(Breuk breuk, int waarde)
        {
            return new Breuk(breuk.tellerValue * waarde , breuk.Noemer);
        }
        public static Breuk operator ++(Breuk breuk)
        {
            var x = breuk.Teller + breuk.Noemer;
            return new Breuk(x, breuk.Noemer);
        }
        public static implicit operator double(Breuk breuk)
        {
            return (double)breuk.Teller / (double)breuk.Noemer;

        }
        public static explicit operator int(Breuk breuk){
            return breuk.Teller/breuk.Noemer;
        }
        public static bool operator true(Breuk breuk)
        {
            return breuk.Teller < breuk.Noemer;
        }

        public static bool operator false(Breuk breuk)
        {
            return !breuk;
        }
        public static bool operator !(Breuk breuk)
        {
            if (breuk)
                return false;
            else return true;
        }
    }
}
