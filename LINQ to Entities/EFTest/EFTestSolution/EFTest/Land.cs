//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class Land
    {
        public Land()
        {
            this.Steden = new HashSet<Stad>();
            this.Talen = new HashSet<Taal>();
        }
    
        public string LandCode { get; set; }
        public string Naam { get; set; }
    
        public virtual ICollection<Stad> Steden { get; set; }
        public virtual ICollection<Taal> Talen { get; set; }
    }
}