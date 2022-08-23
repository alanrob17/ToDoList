// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoListTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ToDoDAL;

    /// <summary>
    /// The test harness.
    /// </summary>
    public class TestHarness
    {
        public static void Main(string[] args)
        {
            // GetTasks();
            GetSingleTask(3);
            // GetAllProjectTasks();
        }

        /// <summary>
        /// The get all project tasks.
        /// </summary>
        private static void GetAllProjectTasks()
        {
            var taskData = new TaskData();
            var tasks = taskData.SelectTasks("level");

            foreach (var task in tasks)
            {
                Console.WriteLine("{0} -- {1} - {2} {3:d} - {4:d} - {5} - {6}", task.ProjectName, task.TaskName, task.TaskDescription, task.StartDate, task.TargetDate, task.Importance, task.Status);
            }
        }

        /// <summary>
        /// Get all tasks.
        /// </summary>
        private static void GetTasks(string taskType)
        {
            var taskData = new TaskData();
            var tasks = taskData.Select();

            foreach (var task in tasks)
            {
                Console.WriteLine("{0}\n{1}\nCreated: {2:d} -- Ends: {3:d}\n{4} - {5}\n\n", task.Name, task.Description, task.StartDate, task.TargetDate, task.Importance, task.Status);
            }
        }

        /// <summary>
        /// Get a single task.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        private static void GetSingleTask(int taskId)
        {
            var taskData = new TaskData();
            var task = taskData.Select(taskId);

            Console.WriteLine("{0}\n{1}\nCreated: {2:d} -- Ends: {3:d}\n{4} - {5}\n\n", task.Name, task.Description, task.StartDate, task.TargetDate, task.Importance, task.Status);
        }
    }
}
