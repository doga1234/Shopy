//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UyumProje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Beden
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Beden()
        {
            this.ÜrünBeden = new HashSet<ÜrünBeden>();
            this.Manken = new HashSet<Manken>();
        }
    
        public int BedenID { get; set; }
        public string bedenAdı { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ÜrünBeden> ÜrünBeden { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manken> Manken { get; set; }
    }
}