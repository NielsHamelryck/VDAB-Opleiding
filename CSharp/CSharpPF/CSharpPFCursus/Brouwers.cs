using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPFCursus
{
    public class Brouwers
    {
        public List<Brouwer> GetBrouwers()
        {
            Brouwer palm = new Brouwer{BrouwerNr = 1, BrouwerNaam = "Palm", Belgisch = true};
            palm.Bieren = new List<Bier> {
                new Bier{BierNr =1,BierNaam="Palm Dobbel",Alcohol=6.2F,Brouwer=palm},
            new Bier{BierNr=2,BierNaam="Palm Green",Alcohol=0.1F,Brouwer=palm},
            new Bier{BierNr=3,BierNaam="Palm Royale",Alcohol=7.5F,Brouwer=palm}
            };

            Brouwer hertogJan = new Brouwer{BrouwerNr=2, BrouwerNaam="Hertog Jan", Belgisch=false};
            hertogJan.Bieren = new List<Bier>{
                new Bier {BierNr=4,BierNaam="Hertog Jan Dubbel", Alcohol=7.0F,Brouwer=hertogJan},
                new Bier {BierNr=5,BierNaam="Hertog Jan Grand Prestige", Alcohol= 10.0F,Brouwer=hertogJan},
               
            };

            Brouwer inBev = new Brouwer { BrouwerNr = 3, BrouwerNaam = "InBev", Belgisch = true };
            inBev.Bieren = new List<Bier> {
                new Bier{BierNr=6,BierNaam="Belle-vue Kriek L.A", Alcohol=1.2F,Brouwer=inBev},
                new Bier{BierNr=7,BierNaam="Belle-vue Kriek", Alcohol=5.2F,Brouwer=inBev},
                new Bier{BierNr=8,BierNaam="Leffe Radieuse", Alcohol=8.2F,Brouwer=inBev},
                new Bier{BierNr=9,BierNaam="Leffe Triple",Alcohol=8.5F,Brouwer=inBev}
            };

            return new List<Brouwer> { palm, hertogJan, inBev };
        }
    }
}
