// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewTask.aspx.cs" company="Software inc.">
//  A.Robson  
// </copyright>
// <summary>
//   Defines the ViewTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using ToDoDAL;
    using ToDoDAL.Components;

    public partial class ViewTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dataPanel.Visible = false;

                if (Page.RouteData.Values["taskid"] != null)
                {
                    var taskId = 0;
                    int.TryParse(Page.RouteData.Values["taskid"].ToString(), out taskId);

                    var taskData = new TaskData();
                    var task = taskData.Select(taskId);
                    hdnPK.Value = task.TaskId.ToString(CultureInfo.InvariantCulture);
                    hdnAddMode.Value = "false";
                    PopulateTaskForm(task);
                    var noteData = new NoteData();
                    var notes = noteData.Select(task.TaskId);
                    
                    if (notes.Count > 0)
                    {
                        this.BindNotes(notes);
                    }
                }

                PopulateStatusList();
                // LoadEditTaskScript();
            }
        }

        /// <summary>
        /// Populate the task form.
        /// </summary>
        /// <param name="task">The task.</param>
        private void PopulateTaskForm(ToDoDAL.Task task)
        {
            var projectData = new ProjectData();
            var project = projectData.Select(task.ProjectId);

            projectTextBox.Text = project.Name;
            nameTextBox.Text = task.Name;
            descriptionTextBox.Text = task.Description;
            targetDateTextBox.Text = task.TargetDate.ToShortDateString();
            importanceTextBox.Text = task.Importance;
            statusTextBox.Text = task.Status;
            startDateTextBox.Text = task.StartDate.ToShortDateString();
        }

        protected void ANSaveButton_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "<font color=\"Red\">ERROR: please validate each field!</font>";

            }
            else
            {
                var taskId = 0;
                int.TryParse(hdnPK.Value, out taskId);

                var entity = new ToDoDAL.Note()
                {
                    TaskId = taskId,
                    Description = anDescriptionTextBox.Text,
                    StartDate = DataConvert.HtmlDateToDotNet(DateTime.Now.ToLongDateString()),
                    TargetDate = DataConvert.HtmlDateToDotNet(anTargetDateTextBox.Text),
                    Status = anStatusDropDownList.SelectedValue
                };
    
                var note = new NoteData();
                int noteId = note.Insert(entity);
    
                if (noteId > 0)
                {
                    divMessageArea.Visible = true;
                    messageLabel.Text = "NoteId: " + noteId;
                    var noteData = new NoteData();
                    var notes = noteData.Select(taskId);

                    this.BindNotes(notes);
                }
            }
        }

        /// <summary>
        /// Load the add note script.
        /// </summary>
        private void LoadEditTaskScript()
        {
            var sb = new StringBuilder();

            //sb.AppendLine("$(document).ready(function() {");
            //sb.AppendLine("$('#addNoteDialog').modal();");
            //sb.AppendLine("});");

            //Page.ClientScript.RegisterStartupScript(this.GetType(), "AddData", sb.ToString(), true);

            sb.AppendLine("$(document).ready(function() {");
            sb.AppendLine("$('#editTaskDialog').modal();");
            sb.AppendLine("});");

            Page.ClientScript.RegisterStartupScript(this.GetType(), "EditTaskData", sb.ToString(), true);
        }

        protected void PopulateStatusList()
        {
            var task = new TaskData();
            var statusList = task.SelectStatusList();

            foreach (var item in statusList)
            {
                anStatusDropDownList.Items.Add(item.Status);
            }
        }

        protected void anStatusCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
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

        protected void editStatusCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
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

        protected void editImportanceCustomValidator_ServerValidate(object sender, ServerValidateEventArgs e)
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

        protected void EditButton_Click(object sender, EventArgs e)
        {
            var alan = hiddenTaskPK.Value;
            
            Response.Redirect("../TaskEdit/" + hdnPK.Value);
        }

        protected void BindNotes(IEnumerable<Note> notes)
        {
            notesGridView.DataSource = notes;
            notesGridView.DataBind();
            dataPanel.Visible = true;
        }
    }
}
