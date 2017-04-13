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


    [Table("tblReportType")]
    public partial class tblReportType
    {
        public static ModelType type = ModelType.REPORT_TYPE;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblReportType()
        {
            tblReports = new HashSet<tblReport>();
        }

       
        
        public int ID { get; set; }

        [JsonIgnore]
        [StringLength(2)]
        public string ConcurrencyID { get; set; }

        [JsonProperty(PropertyName = "name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReport> tblReports { get; set; }
    }
}
