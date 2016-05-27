using System;
using System.Collections.Generic;

namespace TestPF
{
    class Program
    {
        static void Main()
        {   decimal  totaal=0m;
            try{
            Personeel instructeur1 = new Instructeur(1, "Asterix", "de galier", 1700m, "HaDieRomeinen@galie.be", VakGebied.Netwerken);
            Personeel instructeur2 = new Instructeur(2, "Obelix", "de grote", 1700m, "Obelix@menhir.net", VakGebied.Ontwikkeling);
            VerlofPeriode zomervakantie = new VerlofPeriode("ZomerVakantie", new DateTime(2016, 07, 01), new DateTime(2016, 07, 31));
            VerlofPeriode kerstvakantie = new VerlofPeriode("Kerstvakantie", new DateTime(2016, 12, 25), new DateTime(2017, 01, 01));
            
            List<VerlofPeriode> verlof = new List<VerlofPeriode> { zomervakantie, kerstvakantie };
            
            Personeel medewerker1 = new Medewerker(3, "Idefix", "de wolf", 1750m, 10);
            Infrastructuur gebouw1 = new Infrastructuur("Gebouw 1", 1500m);
            Infrastructuur gebouw2 = new Infrastructuur("Gebouw 2", 2500m);

            Personeel.VerlofPeriode = verlof;

            IKosten[] kostenGegevens = new IKosten[5];
            kostenGegevens[0] = instructeur1;
            kostenGegevens[1] = instructeur2;
            kostenGegevens[2] = medewerker1;
            kostenGegevens[3] = gebouw1;
            kostenGegevens[4] = gebouw2;

            

            foreach(var kosten in kostenGegevens)
            {
                totaal += kosten.maandkost;
                kosten.gegevensTonen();
                Console.WriteLine();
            }
           
            Console.WriteLine("-----------------");
            Console.WriteLine("De totaal prijs van de onkosten : "+totaal+" EUR");
            Console.WriteLine();

            

        }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("<Enter> om te sluiten");
            Console.ReadLine();
        }

    }
}
