// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Project.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Project type.
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
    /// The project.
    /// </summary>
    public class Project
    {
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
        /// Gets or sets the order.
        /// </summary>
        public int Order { get; set; }
    }
}
