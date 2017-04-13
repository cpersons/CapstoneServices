namespace TylerEfLibrary
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblReportRole
    {
        public int ID { get; set; }

        public int? reportId { get; set; }

        public int roleId { get; set; }

        public virtual tblReport tblReport { get; set; }
        [JsonProperty(PropertyName = "roleList")]
        public virtual tblRole tblRole { get; set; }
    }
}
