// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditProject.aspx.cs" company="Software inc.">
//   A.Robson
// </copyright>
// <summary>
//   Defines the EditProject type.
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

    public partial class EditProject : System.Web.UI.Page
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
                footerPanel.Visible = false;
            }
        }

        protected void projectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            if (projectId > 0)
            {
                var projectData = new ProjectData();
                var project = projectData.Select(projectId);
                PopulateProjectForm(project);

                dataPanel.Visible = true;
                footerPanel.Visible = true;
            }
        }

        /// <summary>
        /// Populate the project form.
        /// </summary>
        /// <param name="project">The project.</param>
        private void PopulateProjectForm(Project project)
        {
            nameTextBox.Text = project.Name;
            descriptionTextBox.Text = project.Description;
            Order = project.Order;
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);

            var entity = new ToDoDAL.Project()
            {
                ProjectId = projectId,
                Name = nameTextBox.Text,
                Description = descriptionTextBox.Text,
                Order = Order
            };

            if (!Page.IsValid)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "<font color=\"Red\">ERROR: please validate each field!</font>";
                return;
            }

            var project = new ProjectData();
            projectId = project.Update(entity);

            if (projectId > 0)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "ProjectId: " + projectId;
            }
        }

    }
}