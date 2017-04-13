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


    [Table("tblEmailReminder")]
    public partial class tblEmailReminder
    {
        public static ModelType type = ModelType.EMAIL_REMINDER;
        public tblEmailReminder(){
          
        }
        
        public int? userID { get; set; }
        
        public int? reportID { get; set; }
        
        public int ID { get; set; }
        [JsonIgnore]
        public virtual tblReport tblReport { get; set; }
    }
}
