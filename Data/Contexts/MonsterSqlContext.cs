using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;
using Models;

namespace Data.Contexts
{
    public class MonsterSqlContext : IMonsterContext
    {
        public Monster GetMonsterByID(int id)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * From Monster WHERE Id=1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Monster monster = new Monster();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monster.Id = (int)reader["Id"];
                        monster.Name = (string)reader["Name"];
                        monster.Description = (string)reader["Description"];
                    }
                }
                return (monster);
            }
        }
    }
}
