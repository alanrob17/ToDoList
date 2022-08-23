using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ToDoList
{
    using System.Globalization;

    using ToDoDAL;

    public partial class DeleteNote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Page.RouteData.Values["noteId"] != null)
                {
                    var noteId = 0;
                    int.TryParse(Page.RouteData.Values["noteId"].ToString(), out noteId);
                    hiddenNotePK.Value = noteId.ToString(CultureInfo.InvariantCulture);

                    var noteData = new NoteData();
                    var note = noteData.SelectNote(noteId);
                    
                    var taskData = new TaskData();
                    var task = taskData.Select(note.TaskId);
                    hiddenTaskPK.Value = task.TaskId.ToString(CultureInfo.InvariantCulture);

                    PopulateNoteForm(task, note);
                }
            }

        }

        /// <summary>
        /// Populate the note form.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="note">The note.</param>
        private void PopulateNoteForm(ToDoDAL.Task task, Note note)
        {
            taskTextBox.Text = task.Name;
            descriptionTextBox.Text = note.Description;
            startDateTextBox.Text = note.StartDate.ToString("yyyy-MM-dd");
            targetDateTextBox.Text = note.TargetDate.ToString("yyyy-MM-dd");
            statusTextBox.Text = note.Status;
        }

        protected void DeleteButton_ItemDeleted(object sender, EventArgs e)
        {
            var noteId = 0;
            int.TryParse(hiddenNotePK.Value, out noteId);
            
            var noteData = new NoteData();

            if (noteId > 0)
            {
                noteData.Delete(noteId);
            }
            else
            {
                divMessageArea.Visible = true;
                messageLabel.Text = "No task to delete!";
            }

            Response.Redirect("../ViewTask/" + hiddenTaskPK.Value);
        }

        protected void ReturnButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("../ViewTask/" + hiddenTaskPK.Value);
        }
    }
}