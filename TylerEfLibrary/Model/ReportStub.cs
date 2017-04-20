using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TylerEfLibrary.Model
{
    /*  ReportStub allows for faster results return when searching for reports.
     *  This allows us to return simple uniquely identifying info regarding the
     *  reports which the user is looking for, without needing to waste time
     *  loading all the report data. Once a user determines which report stub
     *  to view, then the actual report object which corresponds with the stub
     *  can be opened.
     */
    public class ReportStub
    {
        //include basic info about the report
        public int ID { get; set; }
        public string ReportName { get; set; }
        public DateTime? EmailReminderDate { get; set; }
        public DateTime? DueDate { get; set; }

        //basic constructor
        public ReportStub(int id, string reportName, DateTime? emailReminderDate, DateTime? dueDate)
        {
            this.ID = id;
            this.ReportName = reportName;
            this.EmailReminderDate = emailReminderDate;
            this.DueDate = dueDate;
        }
    }
}
