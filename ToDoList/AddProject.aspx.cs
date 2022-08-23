using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    using ToDoDAL;
    using ToDoDAL.Components;

    public partial class AddProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var entity = new Project()
            {
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
            };

            entity.Order = ProjectData.GetHighestOrderNumber();

            if (!Page.IsValid)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "<font color=\"Red\">ERROR: please validate each field!</font>";
                return;
            }

            var project = new ProjectData();
            var projectId = project.Insert(entity);

            if (projectId > 0)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "ProjectId: " + projectId;
            }
        }
    }
}