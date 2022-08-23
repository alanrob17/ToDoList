// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskOrder.aspx.cs" company="Software Inc.">
//   A.Robson
// </copyright>
// <summary>
//   Defines the TaskOrder type.
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

    using ToDoDAL;

    public partial class TaskOrder : System.Web.UI.Page
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int Order
        {
            get
            {
                return (int)ViewState["Order"];
            }

            set
            {
                ViewState["Order"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataPanel.Visible = false;
            }
        }

        protected void projectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            if (projectId > 0)
            {
                // var taskData = new TaskData();
                // var task = taskData.SelectTasksByOrder(projectId);

                dataPanel.Visible = true;
            }
        }
    }
}