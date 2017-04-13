namespace TylerEfLibrary
{
    using Model;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;


    [Table("tblReview")]
    public partial class tblReview
    {
        public static ModelType type = ModelType.REVIEW;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblReview()
        {
            tblReports = new HashSet<tblReport>();
        }
       
        public int? reviewUser { get; set; }
        
        [Column(TypeName = "date")]
        public DateTime? reviewDate { get; set; }
        
        public int ID { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReport> tblReports { get; set; }
    }
}
