using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BelSekolah.BelSekolahDatabase.Helper
{
    public class ConnStringHelper
    {
        public static string GetConn()
        {
            if (!File.Exists("Database.db"))
            {
                SQLiteConnection.CreateFile("Database.db");
                return "Data Source=Database.db; Version=3";
            }
            return "Data Source=Database.db;Version=3;";
        }

    }
}