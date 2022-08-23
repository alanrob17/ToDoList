// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Task.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Task type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ToDoDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    

    /// <summary>
    /// The task.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

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
        /// Gets or sets the importance.
        /// </summary>
        public string Importance { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public int Order { get; set; }
    }
}

