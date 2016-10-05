using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFrontEnd.Helpers
{
    public static class HtmlHelpers
    {
        public static string GetImageSourceForProductline(this HtmlHelper helper, int productLineID)
        {
            switch(productLineID)
            {
                case 1: return "/Content/Images/classic-car.jpg";
                case 2: return "/Content/Images/motorcycles.jpg";
                case 3: return "/Content/Images/planes.png";
                case 4: return "/Content/Images/ships.png";
                case 5: return "/Content/Images/trains.jpg";
                case 6: return "/Content/Images/trucks&buses.png";
                case 7: return "/Content/Images/vintage-car.jpg";
                default: return "/Content/Images/not-found.jpg";
            }
        }
    }
}