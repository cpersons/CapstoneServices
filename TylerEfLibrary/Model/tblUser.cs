namespace TylerEfLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            tblUserRoles = new HashSet<tblUserRole>();
        }

        public int ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string name { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string email { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUserRole> tblUserRoles { get; set; }
    }
}
