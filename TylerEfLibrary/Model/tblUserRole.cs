namespace TylerEfLibrary
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblUserRole
    {
        public int ID { get; set; }

        public int roleId { get; set; }

        public int userId { get; set; }

        public virtual tblRole tblRole { get; set; }

        public virtual tblUser tblUser { get; set; }
    }
}
