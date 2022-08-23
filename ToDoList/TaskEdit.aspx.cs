namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Globalization;

    using ToDoDAL;
    using ToDoDAL.Components;

    public partial class TaskEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var taskId = 0;

            if (!IsPostBack)
            {
                if (Page.RouteData.Values["taskId"] != null)
                {
                    int.TryParse(Page.RouteData.Values["taskid"].ToString(), out taskId);
                    var taskData = new TaskData();
                    var task = taskData.Select(taskId);
                    
                    hiddenTaskPK.Value = taskId.ToString(CultureInfo.InvariantCulture);

                    PopulateImportanceList();
                    PopulateStatusList();
                    PopulateTaskForm(task);
                }
            }

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var taskId = 0;
            var order = 0;
            var projectId = 0;
            int.TryParse(hiddenTaskPK.Value, out taskId);
            int.TryParse(hiddenProjectPK.Value, out projectId);
            int.TryParse(hiddenOrder.Value, out order);

            var entity = new ToDoDAL.Task
            {
                TaskId = taskId,
                ProjectId = projectId,
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                StartDate = DataConvert.HtmlDateToDotNet(hiddenStartDate.Value),
                TargetDate = DataConvert.HtmlDateToDotNet(targetDateTextBox.Text),
                Importance = importanceDropDownList.SelectedValue,
                Status = statusDropDownList.SelectedValue,
                Order = order
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
                if (entity.Status == "Active")
                {
                    Response.Redirect("../ViewTask/" + taskId);    
                }
                else
                {
                    Response.Redirect("../Default");
                }
                
            }
        }

        private void PopulateTaskForm(ToDoDAL.Task task)
        {
            var projectData = new ProjectData();
            var project = projectData.Select(task.ProjectId);
            hiddenProjectPK.Value = project.ProjectId.ToString(CultureInfo.InvariantCulture);

            projectTextBox.Text = project.Name;
            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            targetDateTextBox.Text = task.TargetDate.ToString("yyyy-MM-dd");
            importanceDropDownList.SelectedValue = task.Importance;
            statusDropDownList.SelectedValue = task.Status;
            hiddenOrder.Value = task.Order.ToString(CultureInfo.InvariantCulture);
            hiddenStartDate.Value = task.StartDate.ToLongDateString();
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

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ViewTask/" + hiddenTaskPK.Value);
        }
    }
}