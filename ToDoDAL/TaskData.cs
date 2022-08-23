// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TaskData.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the TaskData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoDAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Runtime.Remoting.Channels;
    using System.Text;
    using System.Threading.Tasks;
    
    using ToDoDAL.Components;

    /// <summary>
    /// The task data.
    /// </summary>
    public class TaskData
    {
        /// <summary>
        /// Select all tasks.
        /// </summary>
        /// <returns>The <see cref="List"/>tasks.</returns>
        public List<Task> Select()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_Tasks";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Task
                        {
                            TaskId = Convert.ToInt32(dr["TaskId"]),
                            ProjectId = Convert.ToInt32(dr["ProjectId"]),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            StartDate = DataConvert.ConvertTo<DateTime>(dr["StartDate"], default(DateTime)),
                            TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                            Importance = dr["Importance"].ToString(),
                            Status = dr["Status"].ToString(),
                            Order = Convert.ToInt32(dr["Order"])
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select a single task.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <returns>The <see cref="Task"/>task.</returns>
        public Task Select(int taskId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_TaskById";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@taskId", taskId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var entity =
              (from dr in dt.AsEnumerable()
               select new Task()
               {
                   TaskId = Convert.ToInt32(dr["TaskId"]),
                   ProjectId = Convert.ToInt32(dr["ProjectId"]),
                   Name = dr["Name"].ToString(),
                   Description = dr["Description"].ToString(),
                   StartDate = DataConvert.ConvertTo<DateTime>(dr["StartDate"], default(DateTime)),
                   TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                   Importance = dr["Importance"].ToString(),
                   Status = dr["Status"].ToString(),
                   Order = Convert.ToInt32(dr["Order"])
               }).FirstOrDefault();

            return entity;
        }

        /// <summary>
        /// Select all tasks by project.
        /// </summary>
        /// <param name="projectId">The project Id.</param>
        /// <returns>
        /// The <see cref="List"/>tasks.</returns>
        public List<Task> SelectTasksByOrder(int projectId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_TasksByOrder";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ProjectId", projectId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Task
                        {
                            TaskId = Convert.ToInt32(dr["TaskId"]),
                            ProjectId = Convert.ToInt32(dr["ProjectId"]),
                            Name = dr["Name"].ToString(),
                            TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                            Importance = dr["Importance"].ToString(),
                            Status = dr["Status"].ToString(),
                            Order = Convert.ToInt32(dr["Order"])
                        };

            return query.ToList();
        }

        /// <summary>
        /// Select tasks by query value.
        /// </summary>
        /// <param name="show">The query string value.</param>
        /// <returns>The <see cref="List"/>list of tasks.</returns>
        public List<ProjectTask> SelectTasks(string show)
        {
            show = show.ToLowerInvariant();

            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_ProjectTasks";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                if (show.StartsWith("level"))
                {
                    show = show.Substring(6);
                    cmd.Parameters.AddWithValue("@Importance", show);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Importance", null);
                }
                
                if (show.StartsWith("pid"))
                {
                    show = show.Substring(4);
                    var pid = 0;
                    int.TryParse(show, out pid);
                    cmd.Parameters.AddWithValue("@ProjectId", pid);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ProjectId", null);
                }

                if (show == "date")
                {
                    cmd.Parameters.AddWithValue("@TargetDate", DateTime.Now);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@TargetDate", null);
                }

                if (show.StartsWith("status"))
                {
                    show = show.Substring(7);
                    cmd.Parameters.AddWithValue("@Status", show);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Status", null);
                }
                
                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new ProjectTask()
                        {
                            TaskId = Convert.ToInt32(dr["TaskId"]),
                            ProjectId = Convert.ToInt32(dr["ProjectId"]),
                            ProjectName = dr["ProjectName"].ToString(),
                            ProjectDescription = dr["ProjectDescription"].ToString(),
                            ProjectOrder = Convert.ToInt32(dr["ProjectOrder"]),
                            TaskName = dr["TaskName"].ToString(),
                            TaskDescription = dr["TaskDescription"].ToString(),
                            StartDate = DataConvert.ConvertTo<DateTime>(dr["StartDate"], default(DateTime)),
                            TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                            Importance = dr["Importance"].ToString(),
                            Status = dr["Status"].ToString(),
                            TaskOrder = Convert.ToInt32(dr["TaskOrder"])
                        };

            var projectTasks = AddHRefs(query.ToList());
            return projectTasks.ToList();
        }

        /// <summary>
        /// Select tasks for a project.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>The <see cref="List"/>list of tasks.</returns>
        public List<Task> SelectTasks(int projectId)
        {
            var tasks = new List<Task>();

            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_TasksByProjectId";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ProjectId", projectId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Task()
                        {
                            TaskId = Convert.ToInt32(dr["TaskId"]),
                            ProjectId = Convert.ToInt32(dr["ProjectId"]),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            StartDate = DataConvert.ConvertTo<DateTime>(dr["StartDate"], default(DateTime)),
                            TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                            Importance = dr["Importance"].ToString(),
                            Status = dr["Status"].ToString(),
                            Order = Convert.ToInt32(dr["Order"])
                        };

            return query.ToList();
        }

        /// <summary>
        /// Get the highest order number for the current project.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>The <see cref="int"/>highest order number for a project.</returns>
        public static int GetHighestOrderNumber(int projectId)
        {
            int orderNumber = 0;

            if (projectId == 0)
            {
                throw new ArgumentNullException("projectId");
            }
            else
            {
                using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
                {
                    var cmd = new SqlCommand("Get_HighestOrderNumber", cn) { CommandType = CommandType.StoredProcedure };

                    cmd.Parameters.AddWithValue("@ProjectId", projectId);

                    using (cn)
                    {
                        cn.Open();
                        orderNumber = (int)cmd.ExecuteScalar();
                        orderNumber++;
                    }
                }
            }

            return orderNumber;
        }

        /// <summary>
        /// Select disinct list of importance values.
        /// </summary>
        /// <returns>The <see cref="List"/>list of importance values.</returns>
        public List<Task> SelectImportanceList()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_ImportanceList";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Task
                        {
                            Importance = dr["Importance"].ToString()
                        };

            return query.ToList();
        }

        public List<Task> SelectStatusList()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_StatusList";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Task
                        {
                            Status = dr["Status"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Add links to grid cells.
        /// </summary>
        /// <param name="tasks">The tasks.</param>
        /// <returns>The <see cref="IEnumerable"/>tasks with links.</returns>
        private static IEnumerable<ProjectTask> AddHRefs(IEnumerable<ProjectTask> tasks)
        {
            foreach (var task in tasks)
            {
                // Courses.aspx?StudentID={0}
                task.ProjectName = string.Format("<a href=\"../ShowTasks/pid~{0}\">{1}</a>", task.ProjectId, task.ProjectName);
                task.TaskName = string.Format("<a href=\"../ViewTask/{0}\">{1}</a>", task.TaskId, task.TaskName);
                task.Importance = string.Format("<a href=\"../ShowTasks/level~{0}\">{0}</a>", task.Importance);
                task.Status = string.Format("<a href=\"../ShowTasks/status~{0}\">{0}</a>", task.Status);
            }

            return tasks;
        }

        /// <summary>
        /// Insert a new task.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="int"/>Task Id.</returns>
        public int Insert(Task entity)
        {
            var taskId = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Insert_Task", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("TaskId", 0);
                cmd.Parameters.AddWithValue("ProjectId", entity.ProjectId);
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Description", entity.Description);
                cmd.Parameters.AddWithValue("StartDate", entity.StartDate);
                cmd.Parameters.AddWithValue("TargetDate", entity.TargetDate);
                cmd.Parameters.AddWithValue("Importance", entity.Importance);
                cmd.Parameters.AddWithValue("Status", entity.Status);
                cmd.Parameters.AddWithValue("Order", entity.Order);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    taskId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return taskId;
        }

        /// <summary>
        /// Select task list based on a Project.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>
        /// The <see cref="List"/>list of Tasks.</returns>
        public List<Task> SelectTaskList(int projectId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_TaskList";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("ProjectId", projectId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Task
                        {
                            TaskId = Convert.ToInt32(dr["TaskId"]),
                            Name = dr["Name"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Update a task.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="int"/>task Id.</returns>
        public int Update(Task entity)
        {
            var newTaskId = -1;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Update_Task", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@TaskId", entity.TaskId);
                cmd.Parameters.AddWithValue("@ProjectId", entity.ProjectId);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@StartDate", entity.StartDate);
                cmd.Parameters.AddWithValue("@TargetDate", entity.TargetDate);
                cmd.Parameters.AddWithValue("@Importance", entity.Importance);
                cmd.Parameters.AddWithValue("@Status", entity.Status); 
                cmd.Parameters.AddWithValue("@Order", entity.Order);
                var taskIdParameter = new SqlParameter("@TaskId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(taskIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    newTaskId = int.Parse(taskIdParameter.Value.ToString());
                }
            }

            return newTaskId;
        }

        /// <summary>
        /// Update the order of a task.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <param name="name">The name.</param>
        /// <param name="targetDate">The target date.</param>
        /// <param name="importance">The importance.</param>
        /// <param name="status">The status.</param>
        /// <param name="order">The order.</param>
        public void Update(int taskId, string name, string importance, string status, int order)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Update_TaskByOrder", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@TaskId", taskId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Importance", importance);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Order", order);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Delete an existing Task record.
        /// </summary>
        /// <param name="taskId">The task Id.</param>
        public void Delete(int taskId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Delete_Task", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@TaskId", taskId);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

/*
 
"<a href=\"../Default/show'+Convert(varchar(10), r.ArtistId)+'\">'+a.name+'</a>'"
 
 
 
 p.ProjectId, p.Name AS ProjectName, p.Description AS ProjectDescription, p.[Order] AS ProjectOrder, 
		t.TaskId, t.Name AS TaskName, CONVERT(VARCHAR(48), t.Description)+'...' AS TaskDescription, 
		t.StartDate, t.TargetDate, t.Importance, t.Status, t.[Order] AS TaskOrder
*/