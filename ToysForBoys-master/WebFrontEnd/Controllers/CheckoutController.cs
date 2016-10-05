using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFrontEnd.Models;

namespace WebFrontEnd.Views.Checkout
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        public ActionResult ViewCart()
        {
            if (this.Session["cart"] != null)
            {
                return View(((ShoppingCart)this.Session["cart"]).orders);
            }
            else
            {
                return View();
            }
        }
    }
}