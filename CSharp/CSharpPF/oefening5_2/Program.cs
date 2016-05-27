using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oefening5_2
{
    public class Program
    {
        static void Main(string[] args)
        {   //##OEFENING 9.2
            //Personenwagen pw =new Personenwagen("Freddy", 150000, 1500, 120, "Queen", 2, 2);
            //Vrachtwagen vw =new Vrachtwagen("Miller", 30000, 800, 80, "R-Mil-031", 300);
            //Voertuig[] Voertuigen = new Voertuig[2];
            //Voertuigen[0] = pw;
            //Voertuigen[1] = vw;
            //foreach(Voertuig eenVoertuig in Voertuigen)
            //{
            //    eenVoertuig.Afbeelden();
            //    Console.WriteLine("De kyoto score is : {0}",eenVoertuig.GetKyotoScore());
            //}
            //##OEFENING 10.2
            //IVervuiler[] Vervuilers = new IVervuiler[3];
            //Vervuilers[0] = new Personenwagen("Asterix", 15000m, 350, 40f, "1-abc-123", 4, 5);
            //Vervuilers[1] = new Stookketel(5.6f);
            //Vervuilers[2] = new Vrachtwagen("Obelix", 8000m, 1500, 160, "MENHIR", 8000);

            //foreach(IVervuiler vervuiler in Vervuilers)
            //{
            //    Console.WriteLine(vervuiler.GeefVervuiling());
            //}
            //##OEFENING 10.2
            IPrivaat[] PriveGegevens = new IPrivaat[2];
            IMilieu[] MilieuGegevens = new IMilieu[2];
            Personenwagen pw1 = new Personenwagen("Asterix", 15000m, 350, 40f, "1-abc-123", 4, 5);
            Vrachtwagen vw1 = new Vrachtwagen("Obelix", 8000m, 1500, 160, "MENHIR", 8000);
            PriveGegevens[0] = pw1;
            PriveGegevens[1] = vw1;
            MilieuGegevens[0] = pw1;
            MilieuGegevens[1] = vw1;
            foreach (Voertuig voertuig in PriveGegevens)
            {
                Console.WriteLine(voertuig.GeefPrivateData());

                Console.WriteLine(voertuig.GeefMilieuData());
            }
            }

       
    }
}
