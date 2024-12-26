using System;
using System.IO;
using System.Data.SQLite;

namespace BelSekolah.BelSekolahDatabase.Helper
{
    public class ConnStringHelper
    {
        public static string GetConn()
        {
            /* string sourceDatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BelSekolahDatabase", "Database.db");
             MessageBox.Show(sourceDatabasePath);

             string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BelSekolah");
             string targetDatabasePath = Path.Combine(appDataPath, "Database.db");

             if (!Directory.Exists(appDataPath))
             {
                 Directory.CreateDirectory(appDataPath);
             }

             if (!File.Exists(targetDatabasePath))
             {
                 File.Copy(sourceDatabasePath, targetDatabasePath);
             }
             return $@"Data Source={targetDatabasePath};Version=3;";*/


            /*string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.db");
            return $"Data Source={path}; Version=3";*/


            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BelSekolah");
            string databasePath = Path.Combine(appDataPath, "Database.db");

            if (!Directory.Exists(appDataPath))
            {
                Directory.CreateDirectory(appDataPath);
            }

            if (!File.Exists(databasePath))
            {
                string defaultDatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory+"BelSekolahDatabase", "Database.db");
                MessageBox.Show("DefaultPatch = "+defaultDatabasePath+"\ndatabasePatch="+databasePath);
                File.Copy(defaultDatabasePath, databasePath);
            }

            return $"Data Source={databasePath}; Version=3";
        }
    }
}