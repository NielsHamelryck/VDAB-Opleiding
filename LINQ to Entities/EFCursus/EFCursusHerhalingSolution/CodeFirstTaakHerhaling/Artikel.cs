using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTaakHerhaling
{
    [Table("Artikels")]
    public abstract class Artikel
    {

        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual ArtikelGroep ArtikelGroep { get; set; }

        public int ArtikelGroepId { get; set; }
        public ICollection<Leverancier> Leveranciers { get; set; }


    }
}
