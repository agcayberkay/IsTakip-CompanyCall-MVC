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
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.InCall = new HashSet<InCall>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string Competent { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Sector { get; set; }
        public string Province { get; set; }
        public string Distirct { get; set; }
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InCall> InCall { get; set; }
    }
}