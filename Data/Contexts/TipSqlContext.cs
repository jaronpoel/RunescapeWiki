using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;
using Models;
using System.Data;

namespace Data.Contexts
{
    public class TipSqlContext : ITipContext
    {
        public Tip GetTipByMonsterID(int id)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * From Tip WHERE Monsterid = @MonsterId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MonsterId", id);
                    cmd.ExecuteNonQuery();
                    Tip tip = new Tip();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tip.Id = (int)reader["Id"];
                            tip.Name = (string)reader["Name"];
                            tip.Description = (string)reader["Description"];
                            tip.Monsterid = (int)reader["MonsterId"];
                        }
                    }
                    return (tip);
                }
            }
        }
    }
}
