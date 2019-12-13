using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;
using Models;

namespace Data.Contexts
{
    public class AccountSqlContext : IAccountContext
    {

        public Account GetAccountByID(int id)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * From Account WHERE Id=1";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                Account account = new Account();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        account.Id = (int)reader["Id"];
                        account.Name = (string)reader["Name"];
                        account.Kind = (string)reader["Kind"];
                        account.Strength = (int)reader["Strenght"];
                        account.Attack = (int)reader["Attack"];
                        account.Defence = (int)reader["Defence"];
                        account.Slayer = (int)reader["Slayer"];
                    }
                }
                return (account);
            }
        }

        public Account UpdateStats(Account account)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Account SET Attack = @Attack, Defence = @Defence, Strength = @Strength WHERE Id=1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
