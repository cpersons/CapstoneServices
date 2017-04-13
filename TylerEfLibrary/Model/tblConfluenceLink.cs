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


    [Table("tblConfluenceLink")]
    public partial class tblConfluenceLink
    {
        public static ModelType type = ModelType.CONFLUENCE_LINK;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblConfluenceLink()
        {
            tblReports = new HashSet<tblReport>();
            
        }

       
        
        public int ID { get; set; }
        
        [Column(TypeName = "text")]
        public string text { get; set; }
        
        [Column(TypeName = "text")]
        public string link { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblReport> tblReports { get; set; }
    }
}
