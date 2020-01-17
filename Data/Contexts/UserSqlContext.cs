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
                            SqlCommand command_ = new SqlCommand("SELECT ID, Username FROM Users WHERE [Username] = @Username", conn);

                            command_.Parameters.AddWithValue("@Username", username);
                            using (SqlDataReader reader = command_.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    user.Id = (int)reader["ID"];
                                    user.Username = (string)reader["Username"];
                                }
                            }
                            return user;
                        }
                        throw new Exception("The username or password provided is incorrect");
                    }
                }
            }
            catch(SqlException x)
            {
                throw new Exception(x.Message);
            }
        }

        public User GetUserByID(int id)
        {
            try
            {
                using (SqlConnection conn = DataConnection.GetConnection())
                {
                    conn.Open();
                    string query = "Select * From Users WHERE Id = @Id";
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
            catch
            {
                throw new Exception();
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

        public void InsertUser(User user)
        {
            try{
                using (SqlConnection conn = DataConnection.GetConnection())
                {
                    conn.Open();
                    string query = "IF NOT EXISTS (Select 1 from [Users] WHERE Email = @Email) INSERT INTO Users(Email, Username, Password) VALUES (@Email, @Username, @Password) ELSE Throw 50011, 'Email is already in use.', 1";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", user.Email);
                        cmd.Parameters.AddWithValue("@Username", user.Username);
                        cmd.Parameters.AddWithValue("@Password", user.Password);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException x)
            {
                throw new Exception(x.Message);
            }
            
        }
    }
}
