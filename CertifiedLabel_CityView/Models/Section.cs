//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CertifiedLabel_CityView.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            this.CertifiedLabels = new HashSet<CertifiedLabel>();
        }
    
        public int SectionID { get; set; }
        public string SectionDesc { get; set; }
        public int DepartmentID { get; set; }
        public string AccountNumber { get; set; }
        public string SectionAbbrev { get; set; }
        public bool IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CertifiedLabel> CertifiedLabels { get; set; }
        public virtual Department Department { get; set; }
    }
}