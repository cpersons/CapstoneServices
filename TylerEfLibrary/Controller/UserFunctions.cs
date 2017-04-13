using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerEfLibrary
{
    public class UserFunctions
    {
        private ReportModel db = new ReportModel();

        public void addUser(tblUser user)
        {
            db.tblUsers.Add(user);
            db.SaveChanges();
        }
    }
}
