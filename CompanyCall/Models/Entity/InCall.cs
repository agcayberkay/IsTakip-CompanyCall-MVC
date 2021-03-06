//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompanyCall.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class InCall
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public InCall()
        {
            this.InCallDetails = new HashSet<InCallDetails>();
        }
    
        public int ID { get; set; }
        public Nullable<int> CallCompany { get; set; }
        public string Subjects { get; set; }
        public Nullable<bool> Durum { get; set; }
        public string Descriptions { get; set; }
        public Nullable<System.DateTime> Dates { get; set; }
    
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InCallDetails> InCallDetails { get; set; }
    }
}
