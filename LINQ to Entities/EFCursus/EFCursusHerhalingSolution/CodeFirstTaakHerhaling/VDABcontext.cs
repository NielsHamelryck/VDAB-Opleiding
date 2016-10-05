using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstTaakHerhaling
{
    public class VDABcontext : DbContext
    {
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<Leverancier> Leveranciers { get; set; }

        public DbSet<ArtikelGroep> ArtikelGroepen { get; set; } 
    }
}
