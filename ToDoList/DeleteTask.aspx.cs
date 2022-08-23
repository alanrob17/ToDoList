// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteTask.aspx.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the DeleteTask type.
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
    using ToDoDAL.Components;

    public partial class DeleteTask : System.Web.UI.Page
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

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public string StartDate
        {
            get
            {
                return ViewState["StartDate"].ToString();
            }
            set
            {
                ViewState["StartDate"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dataPanel.Visible = false;
                taskPanel.Visible = false;
                footerPanel.Visible = false;
            }
        }

        protected void projectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            if (projectId > 0)
            {
                var taskData = new TaskData();
                var tasks = taskData.SelectTaskList(projectId);
                taskDropDownList.Items.Clear();
                taskDropDownList.DataSource = tasks;
                taskDropDownList.DataTextField = "name";
                taskDropDownList.DataValueField = "taskId";
                taskDropDownList.DataBind();

                taskPanel.Visible = true;
            }
        }

        protected void taskDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var taskId = 0;
            int.TryParse(taskDropDownList.SelectedItem.Value, out taskId);

            if (taskId > 0)
            {
                var taskData = new TaskData();
                var task = taskData.Select(taskId);
                PopulateTaskForm(task);

                dataPanel.Visible = true;
                footerPanel.Visible = true;
            }
        }

        /// <summary>
        /// After a task has been deleted return to default.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void deleteButton_ItemDeleted(object sender, EventArgs e)
        {
            var taskId = 0;
            var projectId = 0;
            int.TryParse(taskDropDownList.SelectedItem.Value, out taskId);
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);
            var task = nameTextBox.Text;

            var taskData = new TaskData();

            if (taskId > 0)
            {
                taskData.Delete(taskId);
            }
            else
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "No task to delete!";
            }

            Response.Redirect("~/Default");
        }

        /// <summary>
        /// The return button click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        protected void returnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }

        /// <summary>
        /// Populate task form.
        /// </summary>
        /// <param name="task">The task.</param>
        private void PopulateTaskForm(ToDoDAL.Task task)
        {
            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            targetDateTextBox.Text = task.TargetDate.ToShortDateString();
            importanceTextBox.Text = task.Importance;
            statusTextBox.Text = task.Status;
            Order = task.Order;
            StartDate = task.StartDate.ToLongDateString();
        }
    }
}