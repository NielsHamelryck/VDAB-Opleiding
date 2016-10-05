using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrontEnd.Models
{
    public class ShoppingCart
    {
        public List<OrderViewModel> orders { get; set; }

        private decimal? _TotalAmount;

        public decimal? TotalAmount
        {
            get 
            {
                _TotalAmount = 0;
                foreach (OrderViewModel order in orders) 
                {
                    _TotalAmount += order.Total;
                }
                return _TotalAmount; 
            
            }
            
        }
        

        public ShoppingCart()
        {
            this.orders = new List<OrderViewModel>();
        }
       
    }
}