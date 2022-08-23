// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditTask.aspx.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the EditTask type.
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

    using WebGrease;

    public partial class EditTask : System.Web.UI.Page
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
                PopulateImportanceList();
                PopulateStatusList();
                PopulateTaskForm(task);

                dataPanel.Visible = true;
                footerPanel.Visible = true;
            }
        }

        protected void PopulateStatusList()
        {
            var task = new TaskData();
            var statusList = task.SelectStatusList();

            foreach (var item in statusList)
            {
                statusDropDownList.Items.Add(item.Status);
            }
        }

        private void PopulateImportanceList()
        {
            var task = new TaskData();
            var importanceList = task.SelectImportanceList();

            foreach (var item in importanceList)
            {
                importanceDropDownList.Items.Add(item.Importance);
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var taskId = 0;
            var projectId = 0;
            int.TryParse(taskDropDownList.SelectedItem.Value, out taskId);
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            var entity = new ToDoDAL.Task
            {
                TaskId = taskId,
                ProjectId = projectId,
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                StartDate = DataConvert.HtmlDateToDotNet(StartDate),
                TargetDate = DataConvert.HtmlDateToDotNet(targetDateTextBox.Text),
                Importance = importanceDropDownList.SelectedValue,
                Status = statusDropDownList.SelectedValue,
                Order = Order
            };

            if (!Page.IsValid)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "<font color=\"Red\">ERROR: please validate each field!</font>";
                return;
            }

            var task = new TaskData();
            taskId = task.Update(entity);

            if (taskId > 0)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "TaskId: " + taskId;
            }
        }

        protected void TaskListDataBound(object sender, EventArgs e)
        {
            taskDropDownList.Items.Insert(0, new ListItem("Select Task", "0"));
        }

        /// <summary>
        /// Populate task form.
        /// </summary>
        /// <param name="task">The task.</param>
        private void PopulateTaskForm(ToDoDAL.Task task)
        {
            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            targetDateTextBox.Text = task.TargetDate.ToString("yyyy-MM-dd");
            importanceDropDownList.SelectedValue = task.Importance;
            statusDropDownList.SelectedValue = task.Status;
            Order = task.Order;
            StartDate = task.StartDate.ToLongDateString();
        }

        protected void importanceCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value == "0")
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }

        protected void statusCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            if (e.Value == "0")
            {
                e.IsValid = false;
            }
            else
            {
                e.IsValid = true;
            }
        }
    }
}