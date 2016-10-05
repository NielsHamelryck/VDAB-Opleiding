using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebFrontEnd.Models
{
    public class ProductListItem
    {
        [Display(Name = "Name")]
        public string ProductName { get; set; }

        [Display(Name = "Scale")]
        public string Scale { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Productline")]
        public string Category { get; set; }

        public int ProductLineID { get; set; }

        [Display(Name = "Price")]
        public decimal BuyPrice { get; set; }

        public int ProductID { get; set; }

        public ProductListItem(Product product)
        {
            ProductName = product.name;
            Category = product.productline.name;
            Description = product.description;
            Scale = product.scale;
            ProductID = product.id;
            ProductLineID = product.productlineId;
            BuyPrice = product.buyPrice ?? 0;
        }

    }
}