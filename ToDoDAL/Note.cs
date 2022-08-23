// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Note.cs" company="Software Inc. ">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Note type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The note.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Gets or sets the note id.
        /// </summary>
        public int NoteId { get; set; }

        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the target date.
        /// </summary>
        public DateTime TargetDate { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }
    }
}
