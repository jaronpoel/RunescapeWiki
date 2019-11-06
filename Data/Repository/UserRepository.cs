using Models;
using System;
using System.Data.SqlClient;

namespace Data
{
    public class UserRepository
    {

        public void AuthenticatorUser(User user)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jaron\Documents\Visual Studio 2017\Projects\RunescapeWiki\Data\Runescape.mdf;Integrated Security=True");
            SqlCommand command = new SqlCommand($"execute AuthenticateUser '{user.Username}', '{user.Password}'", conn);

            conn.Open();
            int result = (int)command.ExecuteScalar();
            conn.Close();

            if(result != 1)
            {
                throw new Exception();
            }
        }
    }
}
