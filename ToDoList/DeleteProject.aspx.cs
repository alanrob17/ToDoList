// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteProject.aspx.cs" company="Software Inc">
//  A.Robson 
// </copyright>
// <summary>
//   Defines the DeleteProject type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using ToDoDAL;
    using ToDoDAL.Components;

    public partial class DeleteProject : System.Web.UI.Page
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

        /// <summary>
        /// After a project has been deleted return to default.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        protected void deleteButton_ItemDeleted(object sender, EventArgs e)
        {
            var projectId = 0;
            int.TryParse(projectDropDownList.SelectedItem.Value, out projectId);
            var project = nameTextBox.Text;

            var projectData = new ProjectData();

            if (projectId > 0)
            {
                projectData.Delete(projectId);
            }
            else
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "No project to delete!";
            }

            Response.Redirect("~/Default");
        }

        /// <summary>
        /// Delete an existing Project record.
        /// </summary>
        /// <param name="projectId">The project Id.</param>
        public void Delete(int projectId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Delete_Project", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ProjectId", projectId);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
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

    }
}