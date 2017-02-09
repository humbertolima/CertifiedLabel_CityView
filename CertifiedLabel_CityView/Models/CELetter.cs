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
    
    public partial class CELetter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CELetter()
        {
            this.CELetterRecipients = new HashSet<CELetterRecipient>();
        }
    
        public Nullable<int> CV_INSERT_IDENTITY { get; set; }
        public string Type { get; set; }
        public int RecordID { get; set; }
        public byte[] C_TimeStamp { get; set; }
        public Nullable<int> CECaseID { get; set; }
        public string EnteredBy { get; set; }
        public Nullable<System.DateTime> dateEntered { get; set; }
        public string Inspector { get; set; }
        public Nullable<bool> flagShowViolations { get; set; }
        public Nullable<int> ActionID { get; set; }
        public Nullable<bool> flagAllowImages { get; set; }
        public string PrintAdministrator { get; set; }
        public Nullable<bool> flagDefaultRecipients { get; set; }
        public string TrackingNumber { get; set; }
        public string CaseNumber { get; set; }
        public string InspectorComments { get; set; }
        public Nullable<bool> flagPost { get; set; }
        public string AllowPrintRole { get; set; }
        public Nullable<int> CaseSectorID { get; set; }
        public Nullable<bool> flagCertified { get; set; }
        public Nullable<bool> flagHasLocalImages { get; set; }
        public Nullable<int> CELienID { get; set; }
        public string NotaryComments { get; set; }
        public Nullable<System.DateTime> datePosted { get; set; }
        public string NotarizedBy { get; set; }
        public Nullable<System.DateTime> dateERecQueue { get; set; }
        public Nullable<bool> eRecQueueCompleted { get; set; }
        public Nullable<bool> eRecQueueReady { get; set; }
        public Nullable<System.DateTime> dateERecQueueCompleted { get; set; }
        public string eRecStatus { get; set; }
    
        public virtual CECase CECase { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CELetterRecipient> CELetterRecipients { get; set; }
        public virtual LookupEmployee LookupEmployee { get; set; }
        public virtual LookupEmployee LookupEmployee1 { get; set; }
        public virtual LookupEmployee LookupEmployee2 { get; set; }
        public virtual LookupEmployee LookupEmployee3 { get; set; }
    }
}
