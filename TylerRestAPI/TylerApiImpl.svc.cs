using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TylerEfLibrary;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using TylerEfLibrary.Model;

namespace TylerRestAPI
{
    public class TylerApiImpl : TylerApiFacade
    {
        private ReportFunctions rf = new TylerEfLibrary.ReportFunctions();
        private StateFunctions st = new TylerEfLibrary.StateFunctions();
        private CategoryFunctions cf = new TylerEfLibrary.CategoryFunctions();
        private UserFunctions uf = new TylerEfLibrary.UserFunctions();
        private JsonUtils ju = new JsonUtils();
      
        public string getStatus()
        {
            tempAdd();
            return "OK";
           
        }

        public int persistReport(Stream stream) {
            try
            {
                tblReport report = (tblReport)jsonRequest(stream,tblReport.type);
                return rf.addReport(report);
            }
            catch(Exception e){
                return -1;
            }
               
        }

        public Stream getReportById(string id) {
            try
            {
                tblReport report = rf.getReportById(Int32.Parse(id));
                return jsonResponse(report);
            } catch { return null; }
        }


        public Stream getReports()
        {
            try
            {
                return jsonResponse(rf.getReports());
            }
            catch { return null; }
        }

        public Stream getReportsByUserId(string id) {
            try
            {
                return jsonResponse(rf.getReportsByUser(Int32.Parse(id)));
            }
            catch
            {
                return null;
            }
        }

        public Stream getUpcomingReportsForUser(string id) {
            try
            {
                return jsonResponse(rf.getUpcomingReports(Int32.Parse(id)));
            }
            catch {
                return null;
            }
        }


        public int updateReport(Stream stream)
        {
            try
            {
                tblReport report = (tblReport)jsonRequest(stream, tblReport.type);
                return rf.updateReport(report);
            }
            catch { return -1; }
        }


        public bool deleteReport(string id)
        {
            try {
               return rf.deleteReport(Int32.Parse(id));
            }
            catch { return false; }
        }


        public int addEmailReminderToReport(Stream stream) {
            try
            {
                tblEmailReminder reminder = (tblEmailReminder)jsonRequest(stream, tblEmailReminder.type);
                return rf.addEmailReminder(reminder);
            }
            catch {
                return -1;
            }
       }

        public bool removeEmailReminderFromReport(string id)
        {
            try
            {
                return rf.removeEmailReminder(Int32.Parse(id));
            }
            catch
            {
                return false;
            }
        }

        public Stream getRemindersToday()
        {
            try
            {
                return jsonResponse(rf.getRemindersToday());
            }
            catch
            {
                return null;
            }
        }

        public Stream getStates()
        {
            return jsonResponse(st.getStates());
        }




        public Stream getCategories()
        {
            return jsonResponse(cf.getCategories());
        }

        public Stream getCategoryById(String id) {
            try {
                return jsonResponse(cf.getCategoryById(Int32.Parse(id)));
            }
            catch{
                return null;
            }
        }

        public int addCategory(Stream stream) {
            try
            {
                tblCategoryType cat = (tblCategoryType)jsonRequest(stream, tblCategoryType.type);
                cat.ID = -1;
                return cf.addCategory(cat);
            }
            catch { return -1; } 
        }

        public int updateCategory(Stream stream)
        {
            try
            {
                tblCategoryType cat = (tblCategoryType)jsonRequest(stream, tblCategoryType.type);
                return cf.updateCategory(cat);
            }
            catch { return -1; }
        }

        public bool deleteCategory(String catId) {
            try
            {
                return cf.deleteCategory(Int32.Parse(catId));
            }
            catch {
                return false;
            }
        }



        private Stream jsonResponse(Object o) {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.Write(ju.serialize(o));
            sw.Flush();
            ms.Position = 0;
            WebOperationContext.Current.OutgoingResponse.ContentType = "application/json";
            return ms;
        }

        private Object jsonRequest(Stream s, ModelType t) {
            StreamReader reader = new StreamReader(s);
            string rawJson = reader.ReadToEnd();
            return ju.deserialize(rawJson,t);
        }

        private void tempAdd() {
             for (int i = 0; i < 25; i++)
              {
            
                tblReport report = new tblReport();
                report.ReportName = "Report" + i;
                report.Frequency = randFreq();
                report.OpenDate = randDate();
                report.FileFormatType = randFormat();
                report.EmailReminderDate = randDate();
                report.Website = "some-site.com";
                report.Notes = "This is report" + i;
                report.DueDate = randDate();

                tblCategoryType type = new tblCategoryType();
                String temp = randType();
                type.Name = temp;
                type.Description = temp+" reports";
                report.tblCategoryType = type;

                tblConfluenceLink link = new tblConfluenceLink();
                link.link = "http://somelink.com";
                link.text = "Confluence Page";
                report.tblConfluenceLink = link;

                tblEmailReminder reminder = new tblEmailReminder();
                reminder.userID = randUser();
                report.tblEmailReminders.Add(reminder);

                tblEmailReminder reminder1 = new tblEmailReminder();
                reminder1.userID = randUser();
                report.tblEmailReminders.Add(reminder1);

                tblReportRole role1 = new tblReportRole();
                role1.roleId = randRole();
                report.tblReportRoles.Add(role1);

                tblReportType rt = new tblReportType();
                String temprt = randRt();
                rt.Name = temprt;
                rt.Description = temprt + " type.";
                report.tblReportType = rt;

                tblReview rev = new tblReview();
                rev.reviewDate = randDate();
                rev.reviewUser = 1;
                report.tblReview = rev;

                tblState state = randState();
                report.tblState = state;
                rf.addReport(report);
            }
        }

        private Random rnd = new Random();
        private String randFreq() {
            List<String> t = new List<String>();
            t.Add("Per Pay Period");
            t.Add("Monthly");
            t.Add("Quareterly");
            t.Add("Annually");
            t.Add("Other (would be state defined)");
            int c = rnd.Next(0, 5);
            return t[c];
        }

        private String randFormat()
        {
            List<String> t = new List<String>();
            t.Add("Fixed Length Text");
            t.Add("Comma Delimeted");
            t.Add("Web Service/API");
            t.Add("Tab Delimited Text");
            t.Add("Special Character Delimited (would include char)");
            int c = rnd.Next(0, 5);
            return t[c];
        }


        private DateTime randDate() {
            return DateTime.Now.AddDays(rnd.Next(1, 366));
        }

        private String randType() {
            List<String> t = new List<String>();
            t.Add("Retirement");
            t.Add("Quarterly Taxes");
            t.Add("Unemployment");
            t.Add("Workers Comp");
            t.Add("Staff Reporting");
            t.Add("Budget");
            t.Add("Annual Financial Reporting");
            t.Add("Other – Financials");
            t.Add("Other – Payroll / HR");
            int c = rnd.Next(0, 9);
            return t[c];
        }

        private int randUser() {
            int u = 3;
            while (u == 3)
            {
                u = rnd.Next(1, 7);
            }
            return u;
        }

        private int randRole() {
            return rnd.Next(1, 4);
        }

        private String randRt() {
            List<String> t = new List<String>();
            t.Add("Report");
            t.Add("File");
            t.Add("Both");
            int c = rnd.Next(0, 3);
            return t[c];
        }

        private tblState randState() {
          tblState n = st.stateById(rnd.Next(1, 59));
            tblState r = new tblState();
            r.abbreviation = n.abbreviation;
            r.commonName = n.commonName;
            return r;
        }


    }
}
