using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using TylerEfLibrary;

namespace TylerRestAPI
{
    /// <summary>
    /// Facade for Tyler Reporting RESTful API
    /// </summary>
    [ServiceContract]
    public interface TylerApiFacade
    {
        /// <name>Status</name>
        /// <method>GET</method>
        /// <path>/</path>
        /// <summary>
        /// Method provided as a status check to verify the service is operation.
        /// </summary>
        /// <returns name="status">String "Ok"</returns>
        [OperationContract]
        [WebGet(UriTemplate ="status",ResponseFormat =WebMessageFormat.Json)]
        string getStatus();

        /// <name>Get All Reports</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/reports</path>
        /// <summary>
        /// Returns all reports.
        /// </summary>
        /// <returns name="report">JSON serialized list of reports.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getReports();

        /// <name>Lookup Report Stubs By User ID</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/reports/stubsByUserId/{id}</path>
        /// <summary>
        /// Returns a list of stubbed reports associated with a user based on his or her role.
        /// </summary>
        /// <param name="id">int of the user's ID</param>
        /// <returns name="report">JSON serialized list of reports.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/stubsByUserId/{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getStubbedReportsByUserId(string id);


        /// <name>Lookup Report By ID</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/reports/reportById/{id}</path>
        /// <summary>
        /// Returns a report for a given ID, empty response if the report doesn't exist.
        /// </summary>
        /// <param name="id">Integer of report ID to lookup</param>
        /// <returns name="report">JSON serialized report.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/reportsById/{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getReportById(string id);


        /// <name>Lookup Reports By User ID</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/reports/reportsByUserId/{id}</path>
        /// <summary>
        /// Returns a list of reports associated with a user based on his or her role.
        /// </summary>
        /// <param name="id">int of the user's ID</param>
        /// <returns name="report">JSON serialized list of reports.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/reportsByUserId/{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getReportsByUserId(string id);


        /// <name>Get Upcoming Reports for User</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/reports/upcomingReportsByUserId/{id}</path>
        /// <summary>
        /// Returns a list of the next ten reports do for a user;
        /// </summary>
        /// <param name="id">int of the user's ID</param>
        /// <returns name="report">JSON serialized list of reports.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/upcomingReportsByUserId/{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getUpcomingReportsForUser(string id);

        /// <name>Add a Report</name>
        /// <method>POST</method>
        /// <path>/TylerApiImpl.svc/reports/addReport</path>
        /// <summary>
        /// Persists a new report to the database.
        /// </summary>
        /// <param name="reportJson">a JSON String of the report to be added.</param>
        /// <returns name="id">Int ID of the report after it is added, -1 if the report was not successfully added.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/addReport", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int persistReport(Stream reportJson);

        /// <name>Update a Report</name>
        /// <method>PUT</method>
        /// <path>/TylerApiImpl.svc/reports/updateReport</path>
        /// <summary>
        /// Updates an existing report with matching ID
        /// </summary>
        /// <param name="reportJson">a JSON String of the report to be updated.</param>
        /// <returns name="id">Int ID of the report if it is updated, -1 if the report was not successfully updated.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/updateReport", Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int updateReport(Stream reportJson);


        /// <name>Add Email Reminder</name>
        /// <method>POST</method>
        /// <path>/TylerApiImpl.svc/reports/addEmailReminder</path>
        /// <summary>
        /// Add an email reminder to a report
        /// </summary>
        /// <param name="reminder">a JSON String of the email reminder to add.</param>
        /// <returns name="id">int ID of the email reminder if it is added successfully, -1 if it is not.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/addEmailReminder", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int addEmailReminderToReport(Stream reminder);


        /// <name>Remove Email Reminder</name>
        /// <method>DELETE</method>
        /// <path>/TylerApiImpl.svc/reports/removeEmailReminder/{id}</path>
        /// <summary>
        /// Remove an email reminder form a report
        /// </summary>
        /// <param name="id">int ID of the reminder object to remove</param>
        /// <returns name="result">bool TRUE if the reminder is successfully removed, FALSE if it was not removed or didn't exist.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/removeEmailReminder/{id}", Method = "DELETE", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        bool removeEmailReminderFromReport(string id);


        /// <name>Delete a Report By ID</name>
        /// <method>DELETE</method>
        /// <path>/TylerApiImpl.svc/reports/deleteReport/{id}</path>
        /// <summary>
        /// Deletes a report by ID
        /// </summary>
        /// <param name="id">Integer of report ID to delete</param>
        /// <returns name="result">Boolean TRUE if delete is successful, FALSE if the delete fails or the report isn't found.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/deleteReport/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        bool deleteReport(string id);


        /// <name>Get States</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/states</path>
        /// <summary>
        /// Returns all states
        /// </summary>
        /// <returns name="states">JSON array of all states stored in the database</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "states", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getStates();


        /// <name>Get Categories</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/categories</path>
        /// <summary>
        /// Returns all report categories
        /// </summary>
        /// <returns name="categories">JSON array of all categories stored in the database.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "categories", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getCategories();

        /// <name>Get Category By ID</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/categories/{id}</path>
        /// <summary>
        /// Returns a category for the given ID, or null if it doesn't exist.
        /// </summary>
        /// <returns name="categories">JSON string of the category object</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "categories/{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getCategoryById(string id);


        /// <name>Add a Category</name>
        /// <method>POST</method>
        /// <path>/TylerApiImpl.svc/categories/addCategory</path>
        /// <summary>
        /// Persists a newc category to the database.
        /// </summary>
        /// <param name="categoryJson">a JSON String of the category to be added.</param>
        /// <returns name="id">Int ID of the category after it is added, -1 if the category was not successfully added.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "categories/addCategory", Method = "POST", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int addCategory(Stream categoryJson);

        /// <name>Update a Category</name>
        /// <method>PUT</method>
        /// <path>/TylerApiImpl.svc/categories/updateCategory</path>
        /// <summary>
        /// Updates an existing category.
        /// </summary>
        /// <param name="categoryJson">a JSON String of the category to be updated</param>
        /// <returns name="id">Int ID of the category after it is successfully updated, -1 if the category doesn't exist.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "categories/updateCategory", Method = "PUT", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int updateCategory(Stream categoryJson);


        /// <name>Delete a Category By ID</name>
        /// <method>DELETE</method>
        /// <path>/TylerApiImpl.svc/categories/deleteCategory/{id}</path>
        /// <summary>
        /// Deletes a category by ID
        /// </summary>
        /// <param name="id">Integer of category ID to delete</param>
        /// <returns name="result">Boolean TRUE if delete is successful, FALSE if the delete fails or the category isn't found.</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "categories/deleteCategory/{id}", Method = "DELETE", ResponseFormat = WebMessageFormat.Json)]
        bool deleteCategory(string id);

        /// <name>Get Email Reminders For Today</name>
        /// <method>GET</method>
        /// <path>/TylerApiImpl.svc/reports/reminderToday</path>
        /// <summary>
        /// Returns a list of all the Email Reminders which are supposed to be sent today.
        /// *NOTE* This REST call is only added for function demonstration in video; the function
        /// normally runs automatically on the server every day.
        /// </summary>
        /// <returns name="reminders">JSON string of the email reminders due today</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "reports/reminderToday", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        Stream getRemindersToday();
    }

}
