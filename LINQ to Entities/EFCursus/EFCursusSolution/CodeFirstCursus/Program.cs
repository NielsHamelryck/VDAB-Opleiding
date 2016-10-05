using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<VDABContext>());
            using (var context = new VDABContext())
            {
                var jean = new Instructeur
                {
                    Familienaam = "Smits",
                    Voornaam = "Jean",
                    InDienst = new DateTime(1994, 8, 1),HeeftRijbewijs = true,
                    Wedde = 1000
                };

                context.Instructeurs.Add(jean);
                context.SaveChanges();
                Console.WriteLine(jean.Id);
                //zoeken op primary key
                Console.WriteLine(context.Instructeurs.Find(1).Familienaam);
            }
        }
    }
}
