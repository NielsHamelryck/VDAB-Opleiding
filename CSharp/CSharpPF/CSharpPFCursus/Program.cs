using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Firma;
using Firma.Personeel;
using Firma.Materiaal;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Threading;


namespace CSharpPFCursus
{

    class Program
    {
         
        static void Main(string[] args)
        {
            Fotokopiemachine machine = new Fotokopiemachine("A01", 0, 0.5m);
            Bediende eenBediende = new Bediende("Asterix", new DateTime(2014, 5, 3), Geslacht.Man, 2400m);
            machine.OnderhoudNodig += eenBediende.DoeOnderhoud;
            machine.Fotokopieer(45);

            
        }
    }
    
}
