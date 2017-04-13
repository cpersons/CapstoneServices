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


    public partial class tblReport
    {

        public static ModelType type = ModelType.REPORT;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblReport()
        {
           
            tblEmailReminders = new HashSet<tblEmailReminder>();
            tblReportRoles = new HashSet<tblReportRole>();
        }
        public int ID { get; set; }
        
        [Required]
        [StringLength(100)]
        [JsonProperty(PropertyName = "reportName")]
        public string ReportName { get; set; }

        [JsonIgnore]
        public int State { get; set; }

        [JsonIgnore]
        public int CategoryTypeID { get; set; }

        [JsonProperty(PropertyName = "frequency")]
        [Required]
        [StringLength(100)]
        public string Frequency { get; set; }

        [JsonProperty(PropertyName = "reportTypeId")]
        [JsonIgnore]
        public int ReportTypeID { get; set; }

        [JsonProperty(PropertyName = "fileFormatType")]
        [Required]
        [StringLength(100)]
        public string FileFormatType { get; set; }

        [JsonProperty(PropertyName = "emailReminderDate")]
        [Column(TypeName = "date")]
        public DateTime? EmailReminderDate { get; set; }

        [JsonProperty(PropertyName = "website")]
        [Required]
        [StringLength(1000)]
        public string Website { get; set; }

        [JsonProperty(PropertyName = "confluencePage")]
        [JsonIgnore]
        public int ConfluencePage { get; set; }
        
        [Required]
        [StringLength(1000)]
        [JsonProperty(PropertyName = "notes")]
        public string Notes { get; set; }

        [JsonIgnore]
        public int? LastReviewID { get; set; }


        [JsonIgnore]
        public int? ConcurrencyID { get; set; }

        [JsonProperty(PropertyName = "openDate")]
        [Column(TypeName = "date")]
        public DateTime? OpenDate { get; set; }

        [JsonProperty(PropertyName = "dueDate")]
        [Column(TypeName = "date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty(PropertyName = "categoryType")]
        public virtual tblCategoryType tblCategoryType { get; set; }

        [JsonProperty(PropertyName = "confluenceLink")]
        public virtual tblConfluenceLink tblConfluenceLink { get; set; }

        [JsonProperty(PropertyName = "emailReminders")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblEmailReminder> tblEmailReminders { get; set; }

        [JsonProperty(PropertyName = "roles")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReportRole> tblReportRoles { get; set; }
        [JsonProperty(PropertyName = "lastReview")]
        public virtual tblReview tblReview { get; set; }

        [JsonProperty(PropertyName = "reportType")]
        public virtual tblReportType tblReportType { get; set; }

        [JsonProperty(PropertyName = "state")]
        public virtual tblState tblState { get; set; }
    }
}
