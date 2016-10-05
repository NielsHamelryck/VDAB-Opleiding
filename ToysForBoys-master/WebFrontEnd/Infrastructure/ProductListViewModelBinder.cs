using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFrontEnd.Models;

namespace WebFrontEnd.Infrastructure
{
    public class ProductListViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType == typeof(ProductListViewModel))
            {
                var request = controllerContext.HttpContext.Request;

                var allKeys = new List<string>();

                var model = new ProductListViewModel();

                model.FilterProductName = request.Form.GetValues("FilterProductName")[0];

                model.FilterProductLines = new List<int>();
                
                foreach (string key in request.Form.Keys)
                {
                    if (key.ToLower().Contains("productline"))
                    {
                        bool filterProductLine = false;
                        bool.TryParse(request.Form.GetValues(key)[0], out filterProductLine);

                        if (filterProductLine)
                        {
                            model.FilterProductLines.Add(int.Parse((key.Remove(0, 11))));
                        }
                    }
                }

                int buyPriceMinimum = 0;
                int.TryParse(request.Form.GetValues("FilterBuyPriceMinimum")[0], out buyPriceMinimum);
                int buyPriceMaximum = 0;
                int.TryParse(request.Form.GetValues("FilterBuyPriceMaximum")[0], out buyPriceMaximum);

                model.FilterBuyPriceMinimum = buyPriceMinimum;
                model.FilterBuyPriceMaximum = buyPriceMaximum;

                if (model.FilterBuyPriceMaximum > 0 && model.FilterBuyPriceMinimum > 0)
                {
                    if (model.FilterBuyPriceMinimum > model.FilterBuyPriceMaximum)
                    {
                        bindingContext.ModelState.AddModelError("FilterBuyPriceMinimum", "Minimum price must be lower than maximum price");
                    }
                }

                return model;
                
            } 
            else
            {
                return base.BindModel(controllerContext, bindingContext);
            }
        }
                
    }
}