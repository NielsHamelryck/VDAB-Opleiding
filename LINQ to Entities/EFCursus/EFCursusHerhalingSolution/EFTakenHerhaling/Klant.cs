//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTakenHerhaling
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klant
    {
        public Klant()
        {
            this.Rekeningen = new HashSet<Rekening>();
        }
    
        public int KlantNr { get; set; }
        public string Voornaam { get; set; }
    
        public virtual ICollection<Rekening> Rekeningen { get; set; }
    }
}
