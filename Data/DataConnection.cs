using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public class DataConnection
    {
        //School
        private static readonly string connectionString = "Server=mssql.fhict.local;Database=dbi392219;User Id = dbi392219; Password=masu1996";
        //Local
        //private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jaron\Desktop\S2 herstart\Project\RunescapeWiki\Data\RuneScape.mdf";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
