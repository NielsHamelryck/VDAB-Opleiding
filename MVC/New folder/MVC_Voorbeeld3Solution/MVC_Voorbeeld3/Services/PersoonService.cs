using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using MVC_Voorbeeld3.Models;

namespace MVC_Voorbeeld3.Services
{
    public class PersoonService
    {
        private static Dictionary<int ,Persoon> personen = new Dictionary<int, Persoon>
        {
            {
                1 , new Persoon{
               ID = 1,
               Voornaam = "Jesse",
               Familienaam = "James",
               Score = 5,
               Wedde = 1000,
               Password = "123",
               Geboren = new DateTime(1966,1,1),
               Gehuwd = false,
               Opmerkingen = "Schurk van het wilde westen",
               Geslacht = Geslacht.Man
                }
                },
            
                {
                2, new Persoon
                {
                    ID=2,
                    Voornaam = "Jane",
                    Familienaam = "Calamity",
                    Score=4,
                    Wedde=2000,
                    Password="123",
                    Geboren=new DateTime(1966,2,2),
                    Gehuwd=false,
                    Opmerkingen="Martha Jane Cannary",
                    Geslacht=Geslacht.Vrouw
                }
                },
            {
                3, new Persoon {
                    ID=3,
                    Voornaam="Billy",
                    Familienaam="The Kid",
                    Score=5,
                    Wedde=3000,
                    Password="123",
                    Geboren=new DateTime(1966,3,3),
                    Gehuwd=false,
                    Opmerkingen="Revolverheld",
                    Geslacht=Geslacht.Man} 
            },
            {
                4, new Persoon {
                    ID=4,
                    Voornaam="Sarah",
                    Familienaam="Bernhardt",
                    Score=3,
                    Wedde=4000,
                    Password="123",
                    Geboren=new DateTime(1966,4,4),
                    Gehuwd=false,
                    Opmerkingen="Rosine Bernardt",
                    Geslacht=Geslacht.Vrouw} 
            }
           
        };

        public List<Persoon> GetAll()
        {
            return personen.Values.ToList();
        }

        public Persoon FindByID(int id)
        {
            return personen[id];
        }

        public void Delete(int id)
        {
            personen.Remove(id);
        }

        public void Opslag(decimal vanWedde, decimal totWedde, decimal percentage)
        {
            foreach (var p in 
                (from persoon in personen.Values where persoon.Wedde >= vanWedde && persoon.Wedde <= totWedde
                select persoon))
            {
                p.Wedde += p.Wedde*percentage/100;
            }
            
        }

        public List<Persoon> VanTotWedde(decimal vanWedde, decimal totWedde)
        {
            return (from persoon in personen.Values
                where persoon.Wedde >= vanWedde && persoon.Wedde <= totWedde
                orderby persoon.Wedde
                select persoon).ToList();
        }

        public void Add(Persoon persoon)
        {
            persoon.ID = personen.Keys.Max() + 1;
            personen.Add(persoon.ID,persoon);
        }
    }
}