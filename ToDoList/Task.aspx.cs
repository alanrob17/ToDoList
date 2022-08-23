// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetTask.aspx.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the GetTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.AspNet.FriendlyUrls;

    public partial class GetTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var taskId = 0;

                var segments = Request.GetFriendlyUrlSegments();

                if (!string.IsNullOrEmpty(Request.Path))
                {
                    taskLabel.Text = Request.Path;
                }
                
                if (segments.Any())
                {
                    taskLabel.Text = "ID: " + segments[0];
                    // taskLabel.Text += "<br/>Key: " + segments[1];
                    // Link.Text = Link.NavigateUrl = FriendlyUrl.Href("~/article", segments[0], segments[1]);
                }

                foreach (var val in Page.RouteData.Values)
                {
                    taskLabel.Text = val.Key;
                    taskLabel.Text += val.Value;
                }

                // Check for a specific artist id to display
                if (Page.RouteData.Values["tid"] != null)
                {
                    // var alan = RouteData.ToString();
                    int.TryParse(RouteData.Values["tid"] as string, out taskId);    
                }

                if (taskId > 0)
                {
                    taskLabel.Text = "<br/>" + taskId;
                }

                // this.GetCount(show);
            }

        }
    }
}