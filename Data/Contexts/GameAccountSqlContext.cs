using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;
using Models;

namespace Data.Contexts
{
    public class GameAccountSqlContext : IGameAccountContext
    {

        public GameAccount GetAccountByID(int id)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * From Account WHERE Id=id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                GameAccount account = new GameAccount();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        account.Id = (int)reader["Id"];
                        account.Name = (string)reader["Name"];
                        account.Kind = (string)reader["Kind"];
                        account.Strength = (int)reader["Strength"];
                        account.Attack = (int)reader["Attack"];
                        account.Defence = (int)reader["Defence"];
                        account.Slayer = (int)reader["Slayer"];
                    }
                }
                return (account);
            }
        }

        public GameAccount UpdateStats(GameAccount account)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Account SET Attack = @Attack, Defence = @Defence, Strength = @Strength, Slayer = @Slayer WHERE Id=id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", account.Id);
                using (cmd)
                {
                    cmd.Parameters.AddWithValue("@Attack", account.Attack);
                    cmd.Parameters.AddWithValue("@Defence", account.Defence);
                    cmd.Parameters.AddWithValue("@Strength", account.Strength);
                    cmd.Parameters.AddWithValue("@Slayer", account.Slayer);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (account);
        }
    }
}
