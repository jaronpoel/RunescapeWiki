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

        public Account UpdateStats(Account account)
        {
            using (SqlConnection conn =
                new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jaron\source\repos\RunescapeWiki4\Data\RunescapeWiki.mdf"))
            {
                conn.Open();
                string query = "UPDATE Account SET Attack = @Attack, Defence = @Defence, Strength = @Strength WHERE Id=1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Attack", account.Attack);
                    cmd.Parameters.AddWithValue("@Defence", account.Defence);
                    cmd.Parameters.AddWithValue("@Strength", account.Strength);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (account);
        }
    }
}
