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
        public User AuthenticatUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DataConnection.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("Select Count(*) From Users WHERE [Username] = @Username AND [Password] = @Password", conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        if ((int)cmd.ExecuteScalar() == 1)
                        {
                            User user = new User();
                            SqlCommand command_ = new SqlCommand("SELECT ID, Username, AccountId FROM Users WHERE [Username] = @Username", conn);

                            command_.Parameters.AddWithValue("@Username", username);
                            using (SqlDataReader reader = command_.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    user.Id = (int)reader["ID"];
                                    user.Username = (string)reader["Username"];
                                    user.AccountId = (int)reader["AccountId"];
                                }
                            }
                            return user;
                        }
                        throw new Exception();
                    }
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        public User GetUserByID(int id)
        {
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "Select * From Users WHERE Id=id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
                User user = new User();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        user.Id = (int)reader["Id"];
                        user.Username = (string)reader["Username"];
                        user.Email = (string)reader["Email"];
                        user.Password = (string)reader["Password"];
                       
                    }
                }
                return (user);
            }
        }

        public User UpdateUser(User user)
        {
            
            using (SqlConnection conn = DataConnection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Users SET Email = @Email, Username = @Username, Password = @Password WHERE Id=@Id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Username", user.Username);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
            return (user);
        }
    }
}
