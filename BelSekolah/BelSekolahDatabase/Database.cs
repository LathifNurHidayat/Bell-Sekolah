using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SQLite;

namespace BelSekolah.BelSekolahDatabase
{
    public class database
    {
        private string connectionString = "Data Source=sounds.db;Version=3;";

        public void CreateTable()
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS Sounds (
                        SoundID INTEGER PRIMARY KEY AUTOINCREMENT,
                        FileName TEXT,
                        FilePath TEXT
                    );";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        #region simpan sound 
        public void SaveSound(string fileName, string filePath)
        {
            string query = "INSERT INTO Sounds (FileName, FilePath) VALUES (@FileName, @FilePath)";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FileName", fileName);
                    command.Parameters.AddWithValue("@FilePath", filePath);
                    command.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region file sound
        public List<string> GetSounds()
        {
            List<string> soundsList = new List<string>();

            string query = "SELECT FileName, FilePath FROM Sounds";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fileName = reader["FileName"].ToString();
                            string filePath = reader["FilePath"].ToString();
                            soundsList.Add($"{fileName} - {filePath}"); // Gabungkan nama file dan path
                        }
                    }
                }
            }

            return soundsList;
        }
        #endregion 
    }
}


