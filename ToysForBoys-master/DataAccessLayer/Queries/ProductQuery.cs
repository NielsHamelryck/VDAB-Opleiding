using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Queries
{
    public class ProductQuery
    {
        public SortQuantityEnum? SortQuantity { get; set; }
        public int? minimumQuantity { get; set; }
        public int? maximumQuantity { get; set; }
        public decimal? minPrice { get; set; }
        public decimal? maxPrice { get; set; }
        public bool? active { get; set; }
    }
}
