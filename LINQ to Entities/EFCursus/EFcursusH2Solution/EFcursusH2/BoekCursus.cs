//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFcursusH2
{
    using System;
    using System.Collections.Generic;
    
    public partial class BoekCursus
    {
        public int BoekNr { get; set; }
        public int CursusNr { get; set; }
        public int VolgNr { get; set; }
    
        public virtual Boek Boek { get; set; }
        public virtual Cursus Cursus { get; set; }
    }
}
