using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;
using Models;

namespace Data.Contexts
{
    public class UserSqlContext : IUserContext
    {
        //    SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jaron\Documents\Visual Studio 2017\Projects\RunescapeWiki\Data\Runescape.mdf;Integrated Security=True");

        //    public void AuthenticatUser(string Username, string Password)
        //    {
        //        SqlCommand command = new SqlCommand($"execute AuthenticateUser '{Username}', '{Password}'", conn);

        //        conn.Open();
        //        int result = (int)command.ExecuteScalar();
        //        conn.Close();

        //        if (result != 1)
        //        {
        //            throw new Exception();
        //        }
        //    }

        public void AuthenticatUser(string Username, string Password)
        {
            User user = new User();
            Username = user.Username;
            Password = user.Password;

            try
            {
                using (SqlConnection conn =
                new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jaron\source\repos\RunescapeWiki4\Data\RunescapeWiki.mdf"))
                {
                    conn.Open();
                    string query = "Select Count(*) From User Where Username = @Username AND Password = @Password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", user.Password);

                        if ((long)cmd.ExecuteScalar() == 1)
                        {
                            SqlCommand command_ = new SqlCommand("SELECT ID, Username FROM User WHERE Username = @Username", conn);
                            SqlDataReader reader = command_.ExecuteReader();
                            while (reader.Read())
                            {
                                user.Id = (int)reader["ID"];
                                user.Username = (string)reader["Username"];
                            }
                        }
                        conn.Close();
                        throw new Exception();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
