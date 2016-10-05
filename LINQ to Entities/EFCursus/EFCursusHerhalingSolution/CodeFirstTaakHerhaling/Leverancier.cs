using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTaakHerhaling
{
    [Table("Leveranciers")]
    public class Leverancier
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public ICollection<Artikel> Artikels { get; set; }
    }
}
