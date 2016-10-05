using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFToysForBoys.Model
{
    public class ProductStatStruct
    {
        public int id { get; set; }
        public string name { get; set; }
        public int countProductsSold { get; set; }
    }

    public class YearStruct
    {
        public int year { get; set; }
        public string display { get; set; }
    }

    public class MonthStruct
    {
        public int month { get; set; }
        public string display { get; set; }
    }
}
