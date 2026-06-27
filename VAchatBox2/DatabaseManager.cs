using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace VAchatBox2
{
    public class CyberTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Reminder { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public static class DatabaseManager
    {
        
        private const string ConnStr =
            "Server=localhost;Database=abchat_db;Uid=root;Pwd=@Ang21v33L;";

        public static void AddTask(string title, string description, DateTime? reminder)
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string sql = @"INSERT INTO tasks (title, description, reminder_date)
                               VALUES (@t, @d, @r)";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@t", title);
                    cmd.Parameters.AddWithValue("@d", description);
                    cmd.Parameters.AddWithValue("@r", reminder.HasValue
                        ? (object)reminder.Value.Date : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<CyberTask> GetAllTasks()
        {
            var list = new List<CyberTask>();
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string sql = "SELECT * FROM tasks ORDER BY created_at DESC";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        list.Add(new CyberTask
                        {
                            Id = rdr.GetInt32("id"),
                            Title = rdr.GetString("title"),
                            Description = rdr.IsDBNull(rdr.GetOrdinal("description"))
                                              ? "" : rdr.GetString("description"),
                            Reminder = rdr.IsDBNull(rdr.GetOrdinal("reminder_date"))
                                              ? (DateTime?)null
                                              : rdr.GetDateTime("reminder_date"),
                            IsCompleted = rdr.GetInt32("is_completed") == 1,
                            CreatedAt = rdr.GetDateTime("created_at")
                        });
                    }
                }
            }
            return list;
        }

        public static void MarkCompleted(int taskId)
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string sql = "UPDATE tasks SET is_completed = 1 WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteTask(int taskId)
        {
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string sql = "DELETE FROM tasks WHERE id = @id";
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", taskId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void LogAction(string action)
        {
            try
            {
                using (var conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string sql = "INSERT INTO activity_log (action) VALUES (@a)";
                    using (var cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@a", action);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch { /* never crash the app over a log failure */ }
        }

        public static List<string> GetRecentLog(int limit = 20)
        {
            var list = new List<string>();
            using (var conn = new MySqlConnection(ConnStr))
            {
                conn.Open();
                string sql = $"SELECT action, logged_at FROM activity_log " +
                             $"ORDER BY logged_at DESC LIMIT {limit}";
                using (var cmd = new MySqlCommand(sql, conn))
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                        list.Add($"[{rdr.GetDateTime("logged_at"):HH:mm:ss}]  " +
                                 rdr.GetString("action"));
                }
            }
            return list;
        }
    }
}