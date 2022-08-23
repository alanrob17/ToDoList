// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteData.cs" company="Software Inc.">
//   Alan Robson
// </copyright>
// <summary>
//   The note data.
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
    /// The note data.
    /// </summary>
    public class NoteData
    {
        /// <summary>
        /// Select note by note Id.
        /// </summary>
        /// <param name="noteId">The note id.</param>
        /// <returns>The <see cref="Note"/>note.</returns>
        public Note SelectNote(int noteId)
        {
            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_NoteById";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@NoteId", noteId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var entity =
              (from dr in dt.AsEnumerable()
               select new Note()
               {
                   TaskId = Convert.ToInt32(dr["TaskId"]),
                   NoteId = Convert.ToInt32(dr["NoteId"]),
                   Description = dr["Description"].ToString(),
                   StartDate = DataConvert.ConvertTo<DateTime>(dr["StartDate"], default(DateTime)),
                   TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                   Status = dr["Status"].ToString()
               }).FirstOrDefault();

            return entity;
        }

        /// <summary>
        /// Select notes attached to a Task.
        /// </summary>
        /// <param name="taskId">The task id.</param>
        /// <returns>The <see cref="List"/>list of notes.</returns>
        public List<Note> Select(int taskId)
        {
            var notes = new List<Note>();

            var dt = new DataTable();

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var sql = "Select_NotesByTaskId";
                var cmd = new SqlCommand(sql, cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@TaskId", taskId);

                var da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            var query = from dr in dt.AsEnumerable()
                        select new Note()
                        {
                            TaskId = Convert.ToInt32(dr["TaskId"]),
                            NoteId = Convert.ToInt32(dr["NoteId"]),
                            Description = dr["Description"].ToString(),
                            StartDate = DataConvert.ConvertTo<DateTime>(dr["StartDate"], default(DateTime)),
                            TargetDate = DataConvert.ConvertTo<DateTime>(dr["TargetDate"], default(DateTime)),
                            Status = dr["Status"].ToString()
                        };

            return query.ToList();
        }

        /// <summary>
        /// Insert a new note.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The <see cref="int"/>note Id.</returns>
        public int Insert(Note entity)
        {
            var noteId = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Insert_Note", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("NoteId", 0);
                cmd.Parameters.AddWithValue("TaskId", entity.TaskId);
                cmd.Parameters.AddWithValue("Description", entity.Description);
                cmd.Parameters.AddWithValue("StartDate", entity.StartDate);
                cmd.Parameters.AddWithValue("TargetDate", entity.TargetDate);
                cmd.Parameters.AddWithValue("Status", entity.Status);
                cmd.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    noteId = (int)cmd.Parameters["@ReturnValue"].Value;
                }
            }

            return noteId;
        }

        /// <summary>
        /// Update a note.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public int Update(Note entity)
        {
            var newNoteId = 0;

            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Update_Note", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@TaskId", entity.TaskId);
                cmd.Parameters.AddWithValue("@NoteId", entity.NoteId);
                cmd.Parameters.AddWithValue("@Description", entity.Description);
                cmd.Parameters.AddWithValue("@StartDate", entity.StartDate);
                cmd.Parameters.AddWithValue("@TargetDate", entity.TargetDate);
                cmd.Parameters.AddWithValue("@Status", entity.Status);
                var noteIdParameter = new SqlParameter("@NoteId", SqlDbType.Int, 4)
                {
                    Direction =
                        ParameterDirection
                        .ReturnValue
                };
                cmd.Parameters.Add(noteIdParameter);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    newNoteId = int.Parse(noteIdParameter.Value.ToString());
                }

                return newNoteId;
            }
        }

        public void Delete(int noteId)
        {
            using (var cn = new SqlConnection(AppSettings.Instance.ConnectString))
            {
                var cmd = new SqlCommand("Delete_Note", cn) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@NoteId", noteId);

                using (cn)
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
