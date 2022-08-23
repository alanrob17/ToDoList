// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Task.aspx.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Task type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.EnterpriseServices;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    using Microsoft.AspNet.FriendlyUrls;

    using Newtonsoft.Json.Converters;

    using ToDoDAL;

    public partial class Task : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var projectId = 0;

                var show = string.Empty;
                
                if (Page.RouteData.Values["show"] != null)
                {
                    show = Page.RouteData.Values["show"].ToString().ToLowerInvariant();
                }

                pageHeaderLabel.Text = SetHeader(show);
            }
        }

        /// <summary>
        /// Set the page header.
        /// </summary>
        /// <param name="show">The show filter value.</param>
        /// <returns>The <see cref="string"/>page header.</returns>
        protected string SetHeader(string show)
        {
            var header = string.Empty;
            var projectName = string.Empty;
            var argument = string.Empty;

            if (show.Substring(0, 3) == "pid")
            {
                argument = show.Substring(4);
                int projectId = 0;
                int.TryParse(argument, out projectId);

                if (projectId > 0)
                {
                    show = "pid";
                    projectName = this.GetProjectName(projectId);
                }
            }

            switch (show)
            {
                case "all":
                    header = "All Tasks";
                    break;
                case "level~high":
                    header = "High Importance Tasks";
                    break;
                case "level~medium":
                    header = "Medium Importance Tasks";
                    break;
                case "level~low":
                    header = "Low Importance Tasks";
                    break;
                case "pid":
                    header = projectName + " Tasks";
                    break;
                case "date":
                    header = "Expired Tasks";
                    break;
                case "status~active":
                    header = "Active Tasks";
                    break;
                case "status~completed":
                    header = "Completed Tasks";
                    break;
                default:
                    header = "Tasks";
                    break;
            }

            return header;
        }

        /// <summary>
        /// Get the project name.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>
        /// The <see cref="string"/>project name.</returns>
        private string GetProjectName(int projectId)
        {
            var projectName = string.Empty;

            var projectData = new ProjectData();
            var project = projectData.Select(projectId);
            
            return project.Name;
        }
    }
}