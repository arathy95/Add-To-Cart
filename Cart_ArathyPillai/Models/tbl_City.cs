//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cart_ArathyPillai.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_City
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_City()
        {
            this.tbl_User = new HashSet<tbl_User>();
        }
    
        public int cityid { get; set; }
        public string cityname { get; set; }
        public Nullable<int> FKcityid { get; set; }
    
        public virtual tbl_State tbl_State { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_User> tbl_User { get; set; }
    }
}