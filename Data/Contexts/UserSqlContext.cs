using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Interfaces.Contexts;

namespace Data.Contexts
{
    class UserSqlContext : IUserContext
    {
        public void AuthenticatUser(string Username, string Password)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jaron\Documents\Visual Studio 2017\Projects\RunescapeWiki\Data\Runescape.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand($"execute AuthenticateUser '{Username}', '{Password}'", conn);

            conn.Open();
            int result = (int)command.ExecuteScalar();
            conn.Close();

            if (result != 1)
            {
                throw new Exception();
            }
        }
    }
}
