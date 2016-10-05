using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer;

namespace WebFrontEnd.Models
{
    public class OrderViewModel
    {
        public Product Product { get; set; }
       
        public int Aantal { get; set; }

        private decimal? _Total;

        public decimal? Total
        {
            get 
            {
                _Total = Product.buyPrice * Aantal;
                return _Total; 
            }
           
        }
        
        
    }
}