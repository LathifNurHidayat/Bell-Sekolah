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
            string databasePath = Path.Combine("Database.db");
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
            }

            return $@"Data Source={databasePath};Version=3;";
            //return $@"Data Source = D:\Database\Database.db; Version=3";
        }
    }
}