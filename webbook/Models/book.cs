//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace webbook.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public book()
        {
            this.orderHistory = new HashSet<orderHistory>();
        }
    
        public int bookID { get; set; }
        public string bookName { get; set; }
        public string bookPublisher { get; set; }
        public int bookPublishYear { get; set; }
        public int bookCategory { get; set; }
        public int bookPrice { get; set; }
        public int quantityAvailable { get; set; }
        public int arrivalDate { get; set; }
    
        public virtual bookType bookType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orderHistory> orderHistory { get; set; }
    }
}
