//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFTakenH2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Personeelslid
    {
        public Personeelslid()
        {
            this.Beschermelingen = new HashSet<Personeelslid>();
        }
    
        public int PersoneelsNr { get; set; }
        public string Voornaam { get; set; }
        public Nullable<int> ManagerNr { get; set; }
    
        public virtual ICollection<Personeelslid> Beschermelingen { get; set; }
        public virtual Personeelslid Manager { get; set; }
    }
}
