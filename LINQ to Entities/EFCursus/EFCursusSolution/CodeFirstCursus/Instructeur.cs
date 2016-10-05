using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstCursus
{
    public class Instructeur
    {
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public decimal Wedde { get; set; }
        public DateTime InDienst { get; set; }
        public bool HeeftRijbewijs { get; set; }
        public void Opslag(decimal percentage)
        {
            Wedde *= (1M + percentage/100M);
        }
    }
}
