using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC_Voorbeeld3.Models;

namespace MVC_Voorbeeld3.Services
{
    public class HoofdzetelService
    {
        public Hoofdzetel Read()
        {
            return new Hoofdzetel
            {
                Straat ="Keizerslaan",
                HuisNr ="11",
                Postcode ="1000",
                Gemeente = "Brussel"
            };
        }
    }
}