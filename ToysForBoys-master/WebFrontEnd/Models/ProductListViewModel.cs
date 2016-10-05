using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFrontEnd.Models
{
	public class ProductListViewModel
	{
        public IEnumerable<Productline> AllProductLines { get; set; }

        public List<int> FilterProductLines { get; set; }

        public string FilterProductName { get; set; }

        [Display(Name ="Minimum price")]
        public int FilterBuyPriceMinimum { get; set; }

        [Display(Name ="Maximum price")]
        public int FilterBuyPriceMaximum { get; set; }

        public bool FilterOnPrice { get { return FilterBuyPriceMaximum > 0; } }

        public IEnumerable<ProductListItem> Products { get; set; }
    }
}