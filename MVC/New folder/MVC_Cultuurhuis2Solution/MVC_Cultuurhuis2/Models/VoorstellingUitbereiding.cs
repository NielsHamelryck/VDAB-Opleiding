using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_Cultuurhuis2.Models
{
    [MetadataType(typeof(VoorstellingProperties))]
    public partial class Voorstelling
    {
        public Int16 Plaatsen { get; set; }
    }
}