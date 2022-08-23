// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditNote.aspx.cs" company="Software Inc.">
//   A.Robson
// </copyright>
// <summary>
//   Defines the EditNote type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoList
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using ToDoDAL;
    using ToDoDAL.Components;

    public partial class EditNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["noteId"] != null)
                {
                    var noteId = 0;
                    int.TryParse(Page.RouteData.Values["noteId"].ToString(), out noteId);

                    var noteData = new NoteData();
                    var note = noteData.SelectNote(noteId);
                    hiddenNotePK.Value = noteId.ToString(CultureInfo.InvariantCulture);

                    var taskData = new TaskData();
                    var task = taskData.Select(note.TaskId);
                    taskTextBox.Text = task.Name;
                    hiddenTaskPK.Value = task.TaskId.ToString(CultureInfo.InvariantCulture);

                    PopulateNoteForm(note);
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var taskId = 0;
            int.TryParse(hiddenTaskPK.Value, out taskId);
            var noteId = 0;
            int.TryParse(hiddenNotePK.Value, out noteId);
            var startDate = hiddenStartDate.Value;

            var entity = new ToDoDAL.Note
            {
                TaskId = taskId,
                NoteId = noteId,
                Description = descriptionTextBox.Text,
                StartDate = DataConvert.HtmlDateToDotNet(startDate),
                TargetDate = DataConvert.HtmlDateToDotNet(targetDateTextBox.Text),
                Status = statusDropDownList.SelectedValue
            };

            if (!Page.IsValid)
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "<font color=\"Red\">ERROR: please validate each field!</font>";
                return;
            }

            var note = new NoteData();
            noteId = note.Update(entity);

            if (noteId > 0)
            {
                Response.Redirect("../ViewTask/" + taskId);
            }
        }

        /// <summary>
        /// Populate the note form.
        /// </summary>
        /// <param name="note">The note.</param>
        private void PopulateNoteForm(Note note)
        {
            descriptionTextBox.Text = note.Description;
            targetDateTextBox.Text = note.TargetDate.ToString("yyyy-MM-dd"); 
            statusDropDownList.SelectedValue = note.Status;
            hiddenStartDate.Value = note.StartDate.ToLongDateString();
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

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../DeleteNote/" + hiddenNotePK.Value);
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
