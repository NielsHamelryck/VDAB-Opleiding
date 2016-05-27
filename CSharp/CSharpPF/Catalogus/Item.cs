using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogus
{
    public class Item
    {
        public string Naam { get; set; }
        public int Code { get; set; }
        public string Category { get; set; }

        public int Size { get; set; }

        public Item(string naam,int code,string category,int size)
        {
            this.Naam = naam;
            this.Code = code;
            this.Category = Category;
            this.Size = size;
        }
        
    }
}
