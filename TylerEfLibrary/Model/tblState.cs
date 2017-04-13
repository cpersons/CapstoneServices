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


    [Table("tblState")]
    public partial class tblState
    {
        public static ModelType type = ModelType.STATE;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblState()
        {
            tblReports = new HashSet<tblReport>();
        }

        public int ID { get; set; }
        
        [StringLength(2)]
        public string abbreviation { get; set; }
        
        [StringLength(50)]
        public string commonName { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReport> tblReports { get; set; }
    }
}
