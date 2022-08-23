// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectData.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   Defines the ProjectData type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ToDoDAL
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ToDoDAL.Components;

    /// <summary>
    /// The project data.
    /// </summary>
    public class ProjectData
    {
        /// <summary>
        /// Select the project list.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>list of projects.</returns>
        public List<Project> SelectProjectList()
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_ProjectList";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Project
                        {
                            ProjectId = Convert.ToInt32(dr["ProjectId"]),
                            Name = dr["Name"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Get the highest product order number.
        /// </summary>
        /// <returns>The <see cref="int"/>highest project order number.</returns>
        public static int GetHighestOrderNumber()
        {
            var orderNumber = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Get_HighestProjectOrderNumber", cn) { CommandType = CommandType.StoredProcedure };

                using (cn)
                {
                    cn.Open();
                    orderNumber = (int)cmd.ExecuteScalar();
                    orderNumber++;
                }
            }

            return orderNumber;
        }

        /// <summary>
        /// Insert project.
        /// </summary>
        /// <param name="entity">The project entity.</param>
        /// <returns>The <see cref="int"/>project Id.</returns>
        public int Insert(Project entity)
        {
            var projectId = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Insert_Project", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("ProjectId", entity.ProjectId);
                cmd.Parameters.AddWithValue("Name", entity.Name);
                cmd.Parameters.AddWithValue("Description", entity.Description);
                cmd.Parameters.AddWithValue("Order", entity.Order);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    projectId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return projectId;
        }

        /// <summary>
        /// Update a project.
        /// </summary>
        /// <param name="entity">The project entity.</param>
        /// <returns>The <see cref="int"/>project Id.</returns>
        public int Update(Project entity)
        {
            var projectId = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Update_Project", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ProjectId", entity.ProjectId);
                cmd.Parameters.AddWithValue("@Name", entity.Name);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@Order", entity.Order);
                var projectIdParameter = new SqlParameter("@ProjectId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(projectIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    projectId = int.Parse(projectIdParameter.Value.ToString());
                }
            }

            return projectId;
        }

        /// <summary>
        /// Update a project.
        /// </summary>
        /// <param name="projectId">The project Id.</param>
        /// <param name="name">The name.</param>
        /// <param name="description">The description.</param>
        /// <param name="order">The order.</param>
        public void Update(int projectId, string name, string description, int order)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Update_ProjectByValues", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@ProjectId", projectId);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@Order", order);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Select a project by Id.
        /// </summary>
        /// <param name="projectId">The project id.</param>
        /// <returns>The <see cref="Project"/>project entity.</returns>
        public Project Select(int projectId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_ProjectById";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@projectId", projectId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var entity =
              (from dr in dt.AsEnumerable()
               select new Project()
               {
                   ProjectId = Convert.ToInt32(dr["ProjectId"]),
                   Name = dr["Name"].ToString(),
                   Description = dr["Description"].ToString(),
                   Order = Convert.ToInt32(dr["Order"])
               }).FirstOrDefault();

            return entity;
        }

        public List<Project> SelectProjectsByOrder()
        {
            var projects = new List<Project>();

            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_ProjectsByOrder";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Project()
                        {
                            ProjectId = Convert.ToInt32(dr["ProjectId"]),
                            Name = dr["Name"].ToString(),
                            Description = dr["Description"].ToString(),
                            Order = Convert.ToInt32(dr["Order"])
                        };

            return query.ToList();
        }


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
    }
}
