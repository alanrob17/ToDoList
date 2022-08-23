namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.SessionState;
    using System.Web.UI;

    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            // RouteConfig.RegisterRoutes(RouteTable.Routes);

            // This is added for working with ASP.NET Validation controls
            string JQueryVer = "1.10.2";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + JQueryVer + ".min.js",
                DebugPath = "~/Scripts/jquery-" + JQueryVer + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + JQueryVer + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(string.Empty, "default/", "~/Default.aspx");
            routes.MapPageRoute(string.Empty, "ShowTasks/{show}", "~/ShowTasks.aspx");
            routes.MapPageRoute(string.Empty, "AddTask/", "~/AddTask.aspx");
            routes.MapPageRoute(string.Empty, "UpdateTask/", "~/EditTask.aspx");
            routes.MapPageRoute(string.Empty, "DeleteTask/", "~/DeleteTask.aspx");
            routes.MapPageRoute(string.Empty, "AddProject/", "~/AddProject.aspx");
            routes.MapPageRoute(string.Empty, "UpdateProject/", "~/EditProject.aspx");
            routes.MapPageRoute(string.Empty, "DeleteProject/", "~/DeleteProject.aspx");
            routes.MapPageRoute(string.Empty, "ProjectOrder/", "~/ProjectOrder.aspx");
            routes.MapPageRoute(string.Empty, "TaskOrder/", "~/TaskOrder.aspx");
            routes.MapPageRoute(string.Empty, "ViewTask/{taskId}", "~/ViewTask.aspx");
            routes.MapPageRoute(string.Empty, "UpdateNote/{noteId}", "~/EditNote.aspx");
            routes.MapPageRoute(string.Empty, "DeleteNote/{noteId}", "~/DeleteNote.aspx");
            routes.MapPageRoute(string.Empty, "TaskEdit/{taskId}", "~/TaskEdit.aspx");
        }
    }
}