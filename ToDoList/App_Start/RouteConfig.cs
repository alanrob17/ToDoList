namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Routing;
    using Microsoft.AspNet.FriendlyUrls;

    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings { AutoRedirectMode = RedirectMode.Permanent };
            routes.EnableFriendlyUrls(settings);

            //// The route name (the 1st parameter) must be unique
            //routes.MapPageRoute(string.Empty, "default/", "~/Default.aspx");
            //routes.MapPageRoute(string.Empty, "ShowTasks/{show}", "~/ShowTasks.aspx");
            //routes.MapPageRoute("item", "item/{tid}", "~/Task.aspx");
            //routes.MapPageRoute("level", "level/{level}", "~/ShowTasks.aspx");
            //routes.MapPageRoute("status", "status/{status}", "~/ShowTasks.aspx");
        }
    }
}
