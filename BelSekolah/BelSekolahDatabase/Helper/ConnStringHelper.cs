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
            /*string folderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BelSekolah");
            if (!System.IO.Directory.Exists(folderPath))
            {
                System.IO.Directory.CreateDirectory(folderPath);
            }
            string databasePath = System.IO.Path.Combine(folderPath, "Database.db");
            if (!System.IO.File.Exists(databasePath))
            {
                System.IO.File.Copy(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.db"), databasePath);
            }

            return $@"Data Source={databasePath};Version=3;";*/

            return @"Data Source = D:\Database\Database.db;Version = 3;";
        }

    }
}