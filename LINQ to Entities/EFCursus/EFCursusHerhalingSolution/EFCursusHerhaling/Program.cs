using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCursusHerhaling
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var entities = new OpleidingenEntities())
            {
                foreach (var vrouwelijkeDocent in (from docent in entities.Docenten select docent))
                {
                    if(vrouwelijkeDocent.Geslacht==Geslacht.Vrouw)
                    Console.WriteLine(vrouwelijkeDocent.Naam.ToString());
                }
            }
        }
    }
}
