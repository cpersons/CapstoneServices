using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TylerEfLibrary
{
    public class ReportFunctions
    {
        private ReportModel db = new ReportModel();
        //Get report by ID
        public tblReport getReportById(int id) {
                return db.tblReports.Find(id);
       }

        //Get all reports
        public List<tblReport> getReports()
        {
            var reports = db.tblReports;
            return reports.ToList<tblReport>();
        }

        //Get report stubs
        public List<ReportStub> getStubReportsByUserId(int id) {
            var reports = (from r in db.tblReports
                           join rr in db.tblReportRoles on r.ID equals rr.reportId
                           join ur in db.tblUserRoles on rr.roleId equals ur.roleId
                           where ur.userId == id
                           select new ReportStub(){ ID = r.ID, DueDate=r.DueDate, EmailReminderDate = r.EmailReminderDate, ReportName = r.ReportName}).Distinct();
            List<ReportStub> stubs = reports.ToList<ReportStub>();
            return stubs;    
        }

        //Update a report
        public int updateReport(tblReport report) {
            tblReport temp = db.tblReports.Find(report.ID);
            if (temp != null)
            {
                return addReport(report);
            }
            else {
                return -1;
            }
        }
        //Persist a report
        public int addReport(tblReport report) {
            try
            {
                //TODO: Cleaner way to do this?
                tblState state = db.tblStates.Find(report.State);
                if (state != null) {
                    report.tblState = state;
                    report.State = state.ID;
                }
                tblCategoryType cat = db.tblCategoryTypes.Find(report.CategoryTypeID);
                if (cat != null) {
                    report.CategoryTypeID = cat.ID;
                    report.tblCategoryType = cat;
                }

                tblReportType type = db.tblReportTypes.Find(report.ReportTypeID);
                if (type != null) {
                    report.ReportTypeID = type.ID;
                    report.tblReportType = type;
                }

                db.tblReports.AddOrUpdate(report);
                db.SaveChanges();
                return report.ID;
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

        }

        //Delete a report
        public bool deleteReport(int id) {
            try
            {
                tblReport r = db.tblReports.Find(id);
                db.tblReports.Remove(r);
                db.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        //Add an email reminder to a report
        public int addEmailReminder(tblEmailReminder reminder) {
            tblReport r = db.tblReports.Find(reminder.reportID);
            r.tblEmailReminders.Add(reminder);
            db.SaveChanges();
            return reminder.ID;
        }


        //Remove an email reminder
        public bool removeEmailReminder(int id) {
            tblEmailReminder e = db.tblEmailReminders.Find(id);
            db.tblEmailReminders.Remove(e);
            db.SaveChanges();
            return true;
        }

        //Reports by user ID
        public List<tblReport> getReportsByUser(int id)
        {
            var reports = (from r in db.tblReports
                           join rr in db.tblReportRoles on r.ID equals rr.reportId
                           join ur in db.tblUserRoles on rr.roleId equals ur.roleId
                           where ur.userId == id
                           select r).Distinct();
            List<tblReport> result = reports.ToList<tblReport>();
            return result;
        }

        public List<tblReport> getUpcomingReports(int userId) {
            var reports = (from r in db.tblReports
                           join rr in db.tblReportRoles on r.ID equals rr.reportId
                           join ur in db.tblUserRoles on rr.roleId equals ur.roleId
                           where ur.userId == userId
                           select r).Distinct().Take(10);
            List<tblReport> result = reports.ToList();
            result.Sort(new DueDateSorter());
            return result;
        }

        /*  
         *  getRemindersToday() function grabs all reports which have email reminder dates = today
         *  
         *  We will have this function automatically run in the background on the server daily, but
         *  we created a REST endpoint to demonstrate the function in the demo video.
         */
        public List<tblEmailReminder> getRemindersToday()
        {
            var query = (from r in db.tblReports
                         join em in db.tblEmailReminders on r.ID equals em.reportID
                         where r.EmailReminderDate == DateTime.Today
                         select em);
            List<tblEmailReminder> result = query.ToList();
            return result;
        }

    }



    class DueDateSorter : Comparer<tblReport>
    {
        public override int Compare(tblReport x, tblReport y)
        {
            if (x.DueDate != null && y.DueDate != null)
            {
                DateTime d1 = (DateTime) x.DueDate;
                DateTime d2 = (DateTime) y.DueDate;
                return d1.CompareTo(d2);
            }
            else {
                return 0;
            }
        }
    }
}
