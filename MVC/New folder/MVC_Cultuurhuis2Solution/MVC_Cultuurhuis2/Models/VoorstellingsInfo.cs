﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Cultuurhuis2.Models
{
    public class VoorstellingsInfo
    {
        public List<Genre> Genres { get; set; }

        public Genre Genre { get; set; }

        public List<Voorstelling> Voorstellingen { get; set; }
    }
}