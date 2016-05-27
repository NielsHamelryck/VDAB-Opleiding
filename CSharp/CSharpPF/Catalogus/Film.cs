using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogus
{
    public class Film : Item
    {
        public string Director { get; set; }
        public string MainActor { get; set; }
        public string MainActress { get; set; }
        public Film(string naam, int code,string category,int size,string director,string mainActor,string mainActress):base(naam,code,category,size)
        {
            this.Director = director;
            this.MainActor = mainActor;
            this.MainActress = mainActress;
        }
        public void Play();
        
    }
}
