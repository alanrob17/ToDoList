// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddTask.aspx.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the AddTask type.
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

    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            targetdateCompareValidator.ValueToCompare = DateTime.Now.ToString("dd/MM/yyyy");
            
            if (!IsPostBack)
            {
                dataPanel.Visible = true;
                footerPanel.Visible = true;
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            var entity = new ToDoDAL.Task
                             {
                                 TaskId = 1,
                                 ProjectId = projectId,
                                 Name = nameTextBox.Text,
                                 Description = descriptionTextBox.Text,
                                 StartDate = DateTime.Now,
                                 TargetDate = DataConvert.HtmlDateToDotNet(targetDateTextBox.Text),
                                 Importance = importanceDropDownList.SelectedValue,
                                 Status = statusDropDownList.SelectedValue
                             };

            entity.Order = TaskData.GetHighestOrderNumber(entity.ProjectId);

            if (!Page.IsValid)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "<font color=\"Red\">ERROR: please validate each field!</font>";
                return;
            }

            var task = new TaskData();
            var taskId = task.Insert(entity);

            if (taskId > 0)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "TaskId: " + taskId;
            }
        }

        protected void projectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            if (projectId > 0)
            {
                dataPanel.Visible = true;
                footerPanel.Visible = true;
            }
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