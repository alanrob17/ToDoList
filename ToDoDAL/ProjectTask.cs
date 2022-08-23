// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectTask.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the ProjectTask type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ProjectTask
    {
        /// <summary>
        /// Gets or sets the project id.
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or sets the project name.
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Gets or sets the project description.
        /// </summary>
        public string ProjectDescription { get; set; }

        /// <summary>
        /// Gets or sets the project order.
        /// </summary>
        public int ProjectOrder { get; set; }

        /// <summary>
        /// Gets or sets the task id.
        /// </summary>
        public int TaskId { get; set; }

        /// <summary>
        /// Gets or sets the task name.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or sets the task description.
        /// </summary>
        public string TaskDescription { get; set; }

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
        /// Gets or sets the task order.
        /// </summary>
        public int TaskOrder { get; set; }
    }
}
